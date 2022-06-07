using MyShop.Models;

namespace MyShop.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(byte id);
        Task<Category> Add(Category Category);
        Category Update(Category Category);
        Category Delete(Category Category);
    }
}
