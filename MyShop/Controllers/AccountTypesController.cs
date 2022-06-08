using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private readonly IAccountTypesService _accountTypeService;

        public AccountTypesController(IAccountTypesService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var accountTypes = await _accountTypeService.GetAll();
            return Ok(accountTypes);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var accountType = await _accountTypeService.GetById(id);
            if (accountType == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(accountType);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(AccountTypes dto)
        {
            //var city = new City { Name = dto.Name };

            await _accountTypeService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] AccountTypes dto)
        {
            var accountType = await _accountTypeService.GetById(id);

            if (accountType == null)
                return NotFound($"No accountType was found with ID: {id}");

            accountType.TypeName = dto.TypeName;

            _accountTypeService.Update(accountType);

            return Ok(accountType);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var accountType = await _accountTypeService.GetById(id);

            if (accountType == null)
                return NotFound($"No accountType was found with ID: {id}");

            _accountTypeService.Delete(accountType);

            return Ok(accountType);
        }
    }
}
