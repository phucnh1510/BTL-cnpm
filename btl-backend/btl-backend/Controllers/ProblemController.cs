using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProblemController : ControllerBase
{
    private readonly ProblemService _problemService;

    public ProblemController(ProblemService problemService)
    {
        _problemService = problemService;
    }

    [HttpGet("all")]
    public IActionResult GetProblemSets(int userId)
    {
        var problems = _problemService.GetProblems(userId);
        if (problems == null)
        {
            return NotFound();
        }
        return Ok(problems);
    }
}