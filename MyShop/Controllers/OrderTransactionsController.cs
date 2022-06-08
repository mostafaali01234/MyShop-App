using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTransactionsController : ControllerBase
    {
        private readonly IOrderTransactionsService _orderTransactionService;

        public OrderTransactionsController(IOrderTransactionsService orderTransactionService)
        {
            _orderTransactionService = orderTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orderTransactions = await _orderTransactionService.GetAll();
            return Ok(orderTransactions);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var orderTransaction = await _orderTransactionService.GetById(id);
            if (orderTransaction == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(orderTransaction);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrdersTransaction dto)
        {
            //var city = new City { Name = dto.Name };

            await _orderTransactionService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] OrdersTransaction dto)
        {
            var orderTransaction = await _orderTransactionService.GetById(id);

            if (orderTransaction == null)
                return NotFound($"No orderTransaction was found with ID: {id}");

            orderTransaction.User_Id = dto.User_Id;
            orderTransaction.Order_Id = dto.Order_Id;
            orderTransaction.Register_Date = dto.Register_Date;
            orderTransaction.Last_Update = dto.Last_Update;
            orderTransaction.Status = dto.Status;

            _orderTransactionService.Update(orderTransaction);

            return Ok(orderTransaction);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var orderTransaction = await _orderTransactionService.GetById(id);

            if (orderTransaction == null)
                return NotFound($"No orderTransaction was found with ID: {id}");

            _orderTransactionService.Delete(orderTransaction);

            return Ok(orderTransaction);
        }
    }
}
