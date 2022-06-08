using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var category = await _categoryService.GetAll();
            return Ok(category);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Category dto)
        {
            //var city = new City { Name = dto.Name };

            await _categoryService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] Category dto)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
                return NotFound($"No category was found with ID: {id}");

            category.Name = dto.Name;
            
            _categoryService.Update(category);

            return Ok(category);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var category = await _categoryService.GetById(id);

            if (category == null)
                return NotFound($"No category was found with ID: {id}");

            _categoryService.Delete(category);

            return Ok(category);
        }
    }
}
