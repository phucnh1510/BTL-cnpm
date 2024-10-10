using btl_backend.Dtos;
using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/problem")]
public class SvController : ControllerBase
{
    private readonly UserService _userService;
    private readonly CodeJudgeService _codeJudgeService;

    public SvController(UserService userService, CodeJudgeService codeJudgeService)
    {
        _userService = userService;
        _codeJudgeService = codeJudgeService;
    }

    [HttpGet("{userid}/all")]
    public async Task<IActionResult> GetProblemSet(int userId)
    {
        var problems = await _userService.GetProblemSet(userId);

        return Ok(problems);
    }

    [HttpGet("{userid}/{problemId}")]
    public IActionResult GetProblem(int userid, int problemId)
    {
        var problem = _userService.GetProblem(userid, problemId);
        if (problem == null)
        {
            return Unauthorized();
        }
        return Ok(problem);
    }

    [HttpGet("{userid}/submissions")]
    public async Task<IActionResult> GetSubmissions(int userId)
    {
        var submissions = await _userService.GetUserSubmissions(userId);
        return Ok(submissions);
    }

    [HttpGet("{userid}/{problemId}/submissions")]
    public async Task<IActionResult> GetProblemSubmissions(int userId, int problemId)
    {
        var submissions = await _userService.GetProblemSubmissions(userId, problemId);
        return Ok(submissions);
    }

    [HttpPost("{userid}/{problemId}/submit")]
    public IActionResult SubmitSolution(int userId, int problemId, string submittedCode, int language)
    {

        return Ok();
    }
}