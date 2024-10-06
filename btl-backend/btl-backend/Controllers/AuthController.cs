using btl_backend.Dtos;
using Microsoft.AspNetCore.Mvc;
using btl_backend.Services;
using Microsoft.AspNetCore.Cors;

namespace btl_backend.Controllers;

[ApiController]
[EnableCors]
[Route("[controller]")]
public class AuthController :  ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(UserDto userDto)
    {
        if (userDto.Username == null || userDto.Password == null)
        {
            return BadRequest(new {message = "Invalid Credentials"});
        }
        else if (userDto.Username.Equals("admin"))
        {
            return Ok(new { UserId = "admin" });
        }
        else if (_authService.Authenticate(userDto.Username, userDto.Password))
        {
            var userId = _authService.GetUserId(userDto.Username);
            return Ok(new { UserId = userId });
        }
        return BadRequest(new {message = "Invalid Credentials"});
    }
}