using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services;
using MyShop.Models;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(byte id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            //var dto = _mapper.Map<MovieDetailsDto>(movie);

            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(User dto)
        {
            //var city = new City { Name = dto.Name };

            await _userService.Add(dto);

            return Ok(dto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] User dto)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound($"No user was found with ID: {id}");

            user.Email = dto.Email;
            user.First_Name = dto.First_Name;
            user.Last_Name = dto.Last_Name;
            user.Last_Login = dto.Last_Login;
            user.PasswordHash = dto.PasswordHash;
            user.Phone = dto.Phone;
            user.Register_Date = dto.Register_Date;
            user.type_Id = dto.type_Id;
            user.UserName = dto.UserName;

            _userService.Update(user);

            return Ok(user);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(byte id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound($"No user was found with ID: {id}");

            _userService.Delete(user);

            return Ok(user);
        }
    }
}
