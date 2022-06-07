using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext _context;

        public ProductsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product Product)
        {
            await _context.AddAsync(Product);
            _context.SaveChanges();

            return Product;
        }

        public Product Delete(Product Product)
        {
            _context.Remove(Product);
            _context.SaveChanges();

            return Product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.OrderBy(x => x.Register_Date).ToListAsync();
        }

        public async Task<Product> GetById(byte id)
        {
            return await _context.Products.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Product Update(Product Product)
        {
            _context.Update(Product);
            _context.SaveChanges();

            return Product;
        }
    }
}
