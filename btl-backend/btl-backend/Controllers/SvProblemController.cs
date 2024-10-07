using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/problem")]
public class SvProblemController : ControllerBase
{
    private readonly ProblemService _problemService;

    public SvProblemController(ProblemService problemService)
    {
        _problemService = problemService;
    }

    // student controler
    [HttpGet("all")]
    public async Task<IActionResult> GetProblemSet(int userId)
    {
        var problems = await _problemService.GetProblems(userId);

        return Ok(problems);
    }

    [HttpGet("{problemId}")]
    public IActionResult GetProblem(int userId, int problemId)
    {
        // TODO: Return problem description with its test code
        return Ok();
    }

    [HttpGet("{problemId}/submissions")]
    public IActionResult GetSubmissions(int userId, int problemId)
    {
        return Ok();
    }

    [HttpPost("{problemId}/submit")]
    public IActionResult SubmitSolution(int userId, int problemId, string solution)
    {
        return Ok();
    }
}