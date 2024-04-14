using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services
{
    public class CartService : ICartService
    {
        BookLibraryDb _bookDb;

        public CartService(BookLibraryDb bookDb)
        {
            _bookDb = bookDb;
        }

        public void AddCartItem(AppUser user, Book book, int quantity)
        {
            Cart cart = _bookDb.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.AppUserId == user.Id);

            if (cart == null)
            {
                cart = new Cart { AppUserId = user.Id };
                _bookDb.Carts.Add(cart);
                _bookDb.SaveChanges();
            }

            if (cart.CartItems == null)
            {
                cart.CartItems = new List<CartItem>();
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(c => c.BookId == book.Id);

            if (cartItem == null)
            {
                cartItem = new CartItem { BookId = book.Id, Quantity = quantity };
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            _bookDb.SaveChanges();
        }

        public void RemoveItem(AppUser user, int itemId)
        {
            CartItem cartItem = _bookDb.CartItems.FirstOrDefault(c => c.Cart.AppUserId == user.Id 
            && c.Id == itemId);

            if (cartItem != null)
            {
                _bookDb.CartItems.Remove(cartItem);
                _bookDb.SaveChanges();
            }
        }

        public void UpdateItem(AppUser user, int itemId, int quantity)
        {
            CartItem cartItem = _bookDb.CartItems.FirstOrDefault(c => c.Cart.AppUserId == user.Id
            && c.Id == itemId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _bookDb.SaveChanges();
            }
        }

        public List<CartItem> UserCartItems(AppUser user)
        {
            List<CartItem> items = _bookDb.CartItems
                .Include(c => c.Book) 
                .Where(c => c.Cart.AppUserId == user.Id)
                .ToList();

            return items;
        }


    }
}
