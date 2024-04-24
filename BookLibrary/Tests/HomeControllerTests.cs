using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Data;
using BookLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookShop.Controllers;

public class HomeControllerTests
{
    private readonly HomeController _controller;
    private readonly Mock<BookLibraryDb> _mockContext;
    private readonly Mock<DbSet<Book>> _mockSet;
    private readonly Mock<DbSet<Genre>> _mockGenreSet;

    public HomeControllerTests()
    {
        _mockContext = new Mock<BookLibraryDb>();
        _mockSet = new Mock<DbSet<Book>>();
        _mockGenreSet = new Mock<DbSet<Genre>>();

        var books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", GenreId = 1, Genre = new Genre { Id = 1, Name = "Genre 1" }},
            new Book { Id = 2, Title = "Book 2", GenreId = 1, Genre = new Genre { Id = 1, Name = "Genre 1" }}
        }.AsQueryable();

        var genres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Genre 1" },
            new Genre { Id = 2, Name = "Genre 2" }
        }.AsQueryable();

        _mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
        _mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
        _mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
        _mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());

        _mockGenreSet.As<IQueryable<Genre>>().Setup(m => m.Provider).Returns(genres.Provider);
        _mockGenreSet.As<IQueryable<Genre>>().Setup(m => m.Expression).Returns(genres.Expression);
        _mockGenreSet.As<IQueryable<Genre>>().Setup(m => m.ElementType).Returns(genres.ElementType);
        _mockGenreSet.As<IQueryable<Genre>>().Setup(m => m.GetEnumerator()).Returns(genres.GetEnumerator());

        _mockContext.Setup(m => m.Books).Returns(_mockSet.Object);
        _mockContext.Setup(m => m.Genres).Returns(_mockGenreSet.Object);

        _controller = new HomeController(_mockContext.Object);
    }

    [Fact]
    public void Index_ReturnsCorrectViewWithModel()
    {
        // Act
        var result = _controller.Index(null) as ViewResult;

        // Assert
        var model = Assert.IsAssignableFrom<IEnumerable<Book>>(result.Model);
        Assert.Equal(2, model.Count()); // Assuming there are two books
        Assert.Equal("Genre 1", model.First().Genre.Name);
    }

    [Fact]
    public void ViewbyCategoury_ReturnsFilteredBooks()
    {
        // Act
        var result = _controller.ViewbyCategoury(1) as ViewResult;

        // Assert
        var model = Assert.IsAssignableFrom<IEnumerable<Book>>(result.Model);
        Assert.All(model, book => Assert.Equal(1, book.GenreId));
        Assert.Equal("Genre 1", _controller.ViewBag.Categourytitle);
    }

    [Fact]
    public void Error_ReturnsErrorView()
    {
        // Act
        var result = _controller.Error() as ViewResult;

        // Assert
        Assert.NotNull(result);
        var model = Assert.IsAssignableFrom<ErrorViewModel>(result.Model);
        Assert.NotNull(model.RequestId);
    }

}
