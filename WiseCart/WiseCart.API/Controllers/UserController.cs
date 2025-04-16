using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;

namespace WiseCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDTO register)
        {
            var result = await _userService.CreateUser(register);

            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
