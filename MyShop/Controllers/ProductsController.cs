using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product dto)
        {
            //var city = new City { Name = dto.Name };

            await _productService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] Product dto)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound($"No product was found with ID: {id}");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Category_Id = dto.Category_Id;
            product.Description = dto.Description;
            product.Register_Date = dto.Register_Date;
            product.Last_Update = dto.Last_Update;
            product.Discount = dto.Discount;
            product.Discount_Start = dto.Discount_Start;
            product.Discount_End = dto.Discount_End;
            product.Quantity = dto.Quantity;

            _productService.Update(product);

            return Ok(product);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound($"No product was found with ID: {id}");

            _productService.Delete(product);

            return Ok(product);
        }
    }
}
