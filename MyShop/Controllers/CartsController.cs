using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartsService _cartService;

        public CartsController(ICartsService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var carts = await _cartService.GetAll();
            return Ok(carts);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var cart = await _cartService.GetById(id);
            if (cart == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(cart);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Cart dto)
        {
            //var city = new City { Name = dto.Name };

            await _cartService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] Cart dto)
        {
            var cart = await _cartService.GetById(id);

            if (cart == null)
                return NotFound($"No cart was found with ID: {id}");

            cart.User_Id = dto.User_Id;
            cart.Total = dto.Total;
            cart.Register_Date = dto.Register_Date;
            cart.Last_Update = dto.Last_Update;
            cart.ItemsTotal = dto.ItemsTotal;
            cart.Discount = dto.Discount;

            _cartService.Update(cart);

            return Ok(cart);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var cart = await _cartService.GetById(id);

            if (cart == null)
                return NotFound($"No cart was found with ID: {id}");

            _cartService.Delete(cart);

            return Ok(cart);
        }
    }
}
