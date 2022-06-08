using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailService;

        public OrderDetailsController(IOrderDetailsService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orderDetails = await _orderDetailService.GetAll();
            return Ok(orderDetails);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var orderDetail = await _orderDetailService.GetById(id);
            if (orderDetail == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(orderDetail);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderDetails dto)
        {
            //var city = new City { Name = dto.Name };

            await _orderDetailService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] OrderDetails dto)
        {
            var orderDetail = await _orderDetailService.GetById(id);

            if (orderDetail == null)
                return NotFound($"No orderDetail was found with ID: {id}");

            orderDetail.Order_Id = dto.Order_Id;
            orderDetail.Total = dto.Total;
            orderDetail.Register_Date = dto.Register_Date;
            orderDetail.Last_Update = dto.Last_Update;
            orderDetail.Discount = dto.Discount;
            orderDetail.Product_Id = dto.Product_Id;
            orderDetail.Quantity = dto.Quantity;

            _orderDetailService.Update(orderDetail);

            return Ok(orderDetail);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var orderDetail = await _orderDetailService.GetById(id);

            if (orderDetail == null)
                return NotFound($"No orderDetail was found with ID: {id}");

            _orderDetailService.Delete(orderDetail);

            return Ok(orderDetail);
        }
    }
}
