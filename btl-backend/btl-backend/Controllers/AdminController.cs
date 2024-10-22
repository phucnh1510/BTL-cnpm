using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController(UserService userService) : ControllerBase
{
    private readonly UserService _userService = userService;

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

    [HttpPost("create/class")]
    public async Task<IActionResult> AddClass(Class @class)
    {
        var succeed = await _userService.AddClassAsync(@class);
        if (!succeed) return BadRequest();
        return Ok(succeed);
    }

    [HttpPost("create/topic")]
    public async Task<IActionResult> AddTopic(Topic topic)
    {
        var succeed = await _userService.AddTopicAsync(topic);
        if (!succeed) return BadRequest();
        return Ok(succeed);
    }

    [HttpGet("get/all-topics")]
    public async Task<IActionResult> GetAllTopics()
    {
        var topics = await _userService.GetAllTopicsAsync();
        // if (topics.Count == 0) return BadRequest();
        return Ok(topics);
    }

    [HttpGet("get/all-class")]
    public async Task<IActionResult> GetAllClasses()
    {
        var classes = await _userService.GetAllClassesAsync();
        // if (classes.Count == 0) return BadRequest();
        return Ok(classes);
    }

    [HttpGet("get/all-problems")]
    public async Task<IActionResult> GetAllProblems()
    {
        var problems = await _userService.GetAllProblemsAsync();
        // if (problems == null) return BadRequest();
        return Ok(problems);
    }

    [HttpGet("get/all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        // if (users == null) return BadRequest();
        return Ok(users);
    }
}