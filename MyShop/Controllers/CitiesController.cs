using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _cityService;

        public CitiesController(ICitiesService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cities = await _cityService.GetAll();
            return Ok(cities);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var city = await _cityService.GetById(id);
            if (city == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(city);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(City dto)
        {
            //var city = new City { Name = dto.Name };

            await _cityService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] City dto)
        {
            var city = await _cityService.GetById(id);

            if (city == null)
                return NotFound($"No city was found with ID: {id}");

            city.State_Id = dto.State_Id;
            city.Name = dto.Name;
           
            _cityService.Update(city);

            return Ok(city);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var city = await _cityService.GetById(id);

            if (city == null)
                return NotFound($"No city was found with ID: {id}");

            _cityService.Delete(city);

            return Ok(city);
        }
    }
}
