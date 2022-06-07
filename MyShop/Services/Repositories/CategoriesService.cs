using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _context;

        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Add(Category Category)
        {
            await _context.AddAsync(Category);
            _context.SaveChanges();

            return Category;
        }

        public Category Delete(Category Category)
        {
            _context.Remove(Category);
            _context.SaveChanges();

            return Category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Category> GetById(byte id)
        {
            return await _context.Categories.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Category Update(Category Category)
        {
            _context.Update(Category);
            _context.SaveChanges();

            return Category;
        }
    }
}
