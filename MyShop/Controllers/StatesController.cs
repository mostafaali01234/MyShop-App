using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStatesService _stateService;

        public StatesController(IStatesService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var states = await _stateService.GetAll();
            return Ok(states);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var state = await _stateService.GetById(id);
            if (state == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(state);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(State dto)
        {
            //var city = new City { Name = dto.Name };

            await _stateService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] State dto)
        {
            var state = await _stateService.GetById(id);

            if (state == null)
                return NotFound($"No state was found with ID: {id}");

            state.Name = dto.Name;
            state.Arrange_id = dto.Arrange_id;

            _stateService.Update(state);

            return Ok(state);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var state = await _stateService.GetById(id);

            if (state == null)
                return NotFound($"No state was found with ID: {id}");

            _stateService.Delete(state);

            return Ok(state);
        }
    }
}
