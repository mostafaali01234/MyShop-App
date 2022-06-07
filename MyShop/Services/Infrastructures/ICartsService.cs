using MyShop.Models;

namespace MyShop.Services
{
    public interface ICartsService
    {
        Task<IEnumerable<Cart>> GetAll();
        Task<Cart> GetById(byte id);
        Task<Cart> Add(Cart Cart);
        Cart Update(Cart Cart);
        Cart Delete(Cart Cart);
    }
}
