using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _orderService;

        public OrdersController(IOrdersService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Order dto)
        {
            //var city = new City { Name = dto.Name };

            await _orderService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] Order dto)
        {
            var order = await _orderService.GetById(id);

            if (order == null)
                return NotFound($"No order was found with ID: {id}");

            order.User_Id = dto.User_Id;
            order.Total = dto.Total;
            order.Register_Date = dto.Register_Date;
            order.Last_Update = dto.Last_Update;
            order.Discount = dto.Discount;
            order.Address_description = dto.Address_description;
            order.City_Id = dto.City_Id;
            order.State_Id = dto.State_Id;
            order.Status = dto.Status;
            order.Items_Discount = dto.Items_Discount;
            order.Items_Total = dto.Items_Total;
            order.Line = dto.Line;
            order.Promo_Code = dto.Promo_Code;
            order.Shipping = dto.Shipping;
            order.Tax = dto.Tax;
            order.type_Id = dto.type_Id;

            _orderService.Update(order);

            return Ok(order);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var order = await _orderService.GetById(id);

            if (order == null)
                return NotFound($"No order was found with ID: {id}");

            _orderService.Delete(order);

            return Ok(order);
        }
    }
}
