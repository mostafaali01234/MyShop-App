using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewsController : ControllerBase
    {
        private readonly IProductReviewsService _productReviewService;

        public ProductReviewsController(IProductReviewsService productReviewService)
        {
            _productReviewService = productReviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var productReviews = await _productReviewService.GetAll();
            return Ok(productReviews);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var productReview = await _productReviewService.GetById(id);
            if (productReview == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(productReview);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductsReviews dto)
        {
            //var city = new City { Name = dto.Name };

            await _productReviewService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] ProductsReviews dto)
        {
            var productReview = await _productReviewService.GetById(id);

            if (productReview == null)
                return NotFound($"No productReview was found with ID: {id}");

            productReview.Cons = dto.Cons;
            productReview.Pros = dto.Pros;
            productReview.Product_Id = dto.Product_Id;
            productReview.User_Id = dto.User_Id;
            productReview.Register_Date = dto.Register_Date;
            productReview.Last_Update = dto.Last_Update;
            productReview.Title = dto.Title;
            productReview.Rating = dto.Rating;

            _productReviewService.Update(productReview);

            return Ok(productReview);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var productReview = await _productReviewService.GetById(id);

            if (productReview == null)
                return NotFound($"No productReview was found with ID: {id}");

            _productReviewService.Delete(productReview);

            return Ok(productReview);
        }
    }
}
