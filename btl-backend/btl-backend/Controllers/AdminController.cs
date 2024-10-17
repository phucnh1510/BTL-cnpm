using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly UserService _userService;

    public AdminController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("create/problem")]
    public async Task<IActionResult> AddProblem(Problem problem)
    {
        var succeed = await _userService.AddProblemAsync(problem);
        if (!succeed) return BadRequest();
        return Ok(succeed);
    }

    [HttpDelete("delete/problem/{problemId}")]
    public async Task<IActionResult> DeleteProblem(int problemId)
    {
        var succeed = await _userService.DeleteProblemAsync(problemId);
        if (!succeed) return BadRequest();
        return Ok(succeed);
    }

    [HttpPost("create/user")]
    public async Task<IActionResult> CreateUser(User user)
    {
        var succeed = await _userService.AddUserAsync(user);
        if (!succeed) return BadRequest();
        return Ok(succeed);
    }

    [HttpDelete("delete/user/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var succeed = await _userService.DeleteUserAsync(userId);
        if (!succeed) return BadRequest();
        return Ok(succeed);
    }
}