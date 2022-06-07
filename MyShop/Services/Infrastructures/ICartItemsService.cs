using MyShop.Models;

namespace MyShop.Services
{
    public interface ICartItemsService
    {
        Task<IEnumerable<CartItem>> GetAll();
        Task<CartItem> GetById(byte id);
        Task<CartItem> Add(CartItem CartItem);
        CartItem Update(CartItem CartItem);
        CartItem Delete(CartItem CartItem);
    }
}
