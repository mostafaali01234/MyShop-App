using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class ProductReviewsService : IProductReviewsService
    {
        private readonly ApplicationDbContext _context;

        public ProductReviewsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductsReviews> Add(ProductsReviews ProductsReview)
        {
            await _context.AddAsync(ProductsReview);
            _context.SaveChanges();

            return ProductsReview;
        }

        public ProductsReviews Delete(ProductsReviews ProductsReview)
        {
            _context.Remove(ProductsReview);
            _context.SaveChanges();

            return ProductsReview;
        }

        public async Task<IEnumerable<ProductsReviews>> GetAll()
        {
            return await _context.ProductsReviews.OrderBy(x => x.Register_Date).ToListAsync();
        }

        public async Task<ProductsReviews> GetById(byte id)
        {
            return await _context.ProductsReviews.SingleOrDefaultAsync(g => g.Id == id);
        }

        public ProductsReviews Update(ProductsReviews ProductsReview)
        {
            _context.Update(ProductsReview);
            _context.SaveChanges();

            return ProductsReview;
        }
    }
}
