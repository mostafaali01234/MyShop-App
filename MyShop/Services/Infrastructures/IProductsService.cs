using MyShop.Models;

namespace MyShop.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(byte id);
        Task<Product> Add(Product Product);
        Product Update(Product Product);
        Product Delete(Product Product);
    }
}
