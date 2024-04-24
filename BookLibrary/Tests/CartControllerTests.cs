using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using BookLibrary.Controllers;
using BookLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using BookLibrary.Data;
using BookLibrary.Services;
using Microsoft.EntityFrameworkCore;

public class CartControllerTests
{
    private readonly CartController _controller;
    private readonly BookLibraryDb _dbContext;
    private readonly UserManager<AppUser> _userManager;

    public CartControllerTests()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var options = new DbContextOptionsBuilder<BookLibraryDb>()
            .UseSqlServer(configuration.GetConnectionString("BookLibraryDBConnection"))
            .Options;

        _dbContext = new BookLibraryDb(options);

        var store = new Mock<IUserStore<AppUser>>();
        _userManager = new UserManager<AppUser>(store.Object, null, null, null, null, null, null, null, null);

        _controller = new CartController(new CartService(_dbContext), _userManager, _dbContext);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
    }

    [Fact]
    public async Task Cart_UserNotLoggedIn_RedirectsToLogin()
    {
        _controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

        var result = _controller.Cart();

        var redirectResult = Assert.IsType<RedirectResult>(result);
        Assert.Equal("/Identity/Account/Login", redirectResult.Url);
    }

    [Fact]
    public async Task Cart_UserLoggedIn_ReturnsViewWithItems()
    {
        var user = new AppUser { UserName = "user@example.com", Email = "user@example.com" };
        await _userManager.CreateAsync(user, "Password123!");
        _controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        }, "TestAuthType"));

        var result = _controller.Cart();

        var viewResult = Assert.IsType<ViewResult>(result);
        await _userManager.DeleteAsync(user); // Clean up test user
    }

    [Fact]
    public async Task AddCartItem_UserNotLoggedIn_RedirectsToLogin()
    {
        _controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

        var result = _controller.AddCartItem(1, 1);

        var redirectResult = Assert.IsType<RedirectResult>(result);
        Assert.Equal("/Identity/Account/Login", redirectResult.Url);
    }

    [Fact]
    public async Task AddCartItem_ItemNotFound_ReturnsNotFoundResult()
    {
        var user = new AppUser { UserName = "user@example.com", Email = "user@example.com" };
        await _userManager.CreateAsync(user, "Password123!");
        _controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        }, "TestAuthType"));

        var result = _controller.AddCartItem(9999, 1); // Assuming 9999 is a non-existent item ID

        Assert.IsType<NotFoundResult>(result);
        await _userManager.DeleteAsync(user); // Clean up test user
    }

    [Fact]
    public async Task AddCartItem_ValidItem_RedirectsToCart()
    {
        var user = new AppUser { UserName = "validuser@example.com", Email = "validuser@example.com" };
        await _userManager.CreateAsync(user, "Password123!");
        _controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id)
        }, "TestAuthType"));

        var book = new Book { Title = "Test Book", Price = 19 };
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();

        var result = _controller.AddCartItem(book.Id, 1);

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Cart", redirectResult.ActionName);

        await _userManager.DeleteAsync(user); // Clean up test user
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync(); // Clean up test book
    }

    [Fact]
    public async Task UpdateItem_UserLoggedIn_UpdatesAndRedirects()
    {
        var user = new AppUser { UserName = "updateuser@example.com", Email = "updateuser@example.com" };
        await _userManager.CreateAsync(user, "Password123!");
        var cart = new Cart { AppUserId = user.Id };
        _dbContext.Carts.Add(cart);
        await _dbContext.SaveChangesAsync();

        var book = new Book { Title = "Test Update Book", Price = 39 };
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();

        var cartItem = new CartItem { BookId = book.Id, CartId = cart.Id, Quantity = 1 };
        _dbContext.CartItems.Add(cartItem);
        await _dbContext.SaveChangesAsync();

        _controller.ControllerContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
        new Claim(ClaimTypes.NameIdentifier, user.Id)
        }, "TestAuthType"));

        var result = _controller.UpdateItem(cartItem.Id, 3);

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Cart", redirectResult.ActionName);

        var updatedItem = await _dbContext.CartItems.FindAsync(cartItem.Id);
        Assert.Equal(3, updatedItem.Quantity);

        await _userManager.DeleteAsync(user); 
        _dbContext.Books.Remove(book);
        _dbContext.CartItems.Remove(cartItem);
        _dbContext.Carts.Remove(cart);
        await _dbContext.SaveChangesAsync();
    }

}
