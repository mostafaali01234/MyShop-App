using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsService _cartItemService;

        public CartItemsController(ICartItemsService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cartItems = await _cartItemService.GetAll();
            return Ok(cartItems);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var cartItem = await _cartItemService.GetById(id);
            if (cartItem == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(cartItem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CartItem dto)
        {
            //var city = new City { Name = dto.Name };

            await _cartItemService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] CartItem dto)
        {
            var cartItem = await _cartItemService.GetById(id);

            if (cartItem == null)
                return NotFound($"No cartItem was found with ID: {id}");

            cartItem.Quantity = dto.Quantity;
            cartItem.Total = dto.Total;
            cartItem.Register_Date = dto.Register_Date;
            cartItem.Last_Update = dto.Last_Update;
            cartItem.Discount = dto.Discount;
            cartItem.Cart_Id = dto.Cart_Id;
            cartItem.Price = dto.Price;
            cartItem.Product_Id = dto.Product_Id;

            _cartItemService.Update(cartItem);

            return Ok(cartItem);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var cartItem = await _cartItemService.GetById(id);

            if (cartItem == null)
                return NotFound($"No cartItem was found with ID: {id}");

            _cartItemService.Delete(cartItem);

            return Ok(cartItem);
        }
    }
}
