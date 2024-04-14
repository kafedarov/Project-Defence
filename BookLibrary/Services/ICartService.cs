using BookLibrary.Models;

namespace BookLibrary.Services
{
    public interface ICartService
    {
        List<CartItem> UserCartItems(AppUser user);
        void AddCartItem(AppUser user, Book book, int quantity);
        void UpdateItem(AppUser user, int itemId, int quantity);
        void RemoveItem(AppUser user, int itemId);
    }
}
