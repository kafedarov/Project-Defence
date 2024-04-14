using BookLibrary.Data;
using BookLibrary.Models;
using BookLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class CartController : Controller
    {
        UserManager<AppUser> _appUser;
        ICartService _cartServ;
        BookLibraryDb _bookDb;
        

        public CartController(ICartService cartServ, UserManager<AppUser> appUser, BookLibraryDb bookDb)
        {
            _appUser = appUser;
            _cartServ = cartServ;
            _bookDb = bookDb;
        }

        public IActionResult Cart()
        {
            AppUser user = _appUser.GetUserAsync(User).Result;

            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            var items = _cartServ.UserCartItems(user);
            return View(items);
        }


        [HttpPost]
        public IActionResult AddCartItem(int id, int quantity)
        {
            AppUser user = _appUser.GetUserAsync(User).Result;

            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            Book bookItem = _bookDb.Books.SingleOrDefault(b => b.Id == id);

            if (bookItem == null)
            {
                return NotFound();
            }

            _cartServ.AddCartItem(user, bookItem, quantity);
            return RedirectToAction("Cart");
        }


        [HttpPost]
        public IActionResult RemoveItem(int itemId)
        {
            AppUser user = _appUser.GetUserAsync(User).Result;

            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            _cartServ.RemoveItem(user, itemId);
            
            return RedirectToAction("Cart");
        }


        [HttpPost]
        public IActionResult UpdateItem(int itemId, int quantity) {

            AppUser user = _appUser.GetUserAsync(User).Result;

            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            _cartServ.UpdateItem(user, itemId, quantity);
            return RedirectToAction("Cart");
        }
    }
}
