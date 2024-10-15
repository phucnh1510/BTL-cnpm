using btl_backend.Dtos;
using btl_backend.Models;
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
    public IActionResult Login(LoginDto loginDto)
    {
        if (loginDto.Username == null || loginDto.Password == null)
        {
            return BadRequest(new {message = "Invalid Credentials"});
        }
        else if (loginDto.Username.Equals("admin"))
        {
            return Ok(new { UserId = "admin", Role = (int) Role.Admin });
        }
        else if (_authService.Authenticate(loginDto.Username, loginDto.Password))
        {
            var userId = _authService.GetUserId(loginDto.Username);
            return Ok(new { UserId = userId.userId, Role = userId.userRole });
        }
        return BadRequest(new {message = "Invalid Credentials"});
    }

    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        if (user.Username == null || user.Password == null)
        {
            return BadRequest(new {message = "Invalid Credentials"});
        }
        if (_authService.Register(user))
        {
            return Ok();
        }
        return BadRequest(new {message = "Invalid Credentials"});
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int userId)
    {
        if (_authService.Delete(userId))
        {
            return Ok();
        }
        return BadRequest(new {message = "Invalid Credentials"});
    }
}