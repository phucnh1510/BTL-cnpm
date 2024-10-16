using btl_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{

    [HttpPost("create/problem")]
    public IActionResult CreateProblem(Problem problem)
    {
        return Ok();
    }

    [HttpDelete("delete/problem")]
    public IActionResult DeleteProblem(int problemId)
    {
        return Ok();
    }

    [HttpPost("create/user")]
    public IActionResult CreateUser(User user)
    {
        return Ok();
    }

    [HttpDelete("delete/user")]
    public IActionResult DeleteUser(int userId)
    {
        return Ok();
    }
}