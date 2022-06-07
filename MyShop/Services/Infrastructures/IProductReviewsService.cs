using MyShop.Models;

namespace MyShop.Services
{
    public interface IProductReviewsService
    {
        Task<IEnumerable<ProductsReviews>> GetAll();
        Task<ProductsReviews> GetById(byte id);
        Task<ProductsReviews> Add(ProductsReviews ProductsReview);
        ProductsReviews Update(ProductsReviews ProductsReview);
        ProductsReviews Delete(ProductsReviews ProductsReview);
    }
}
