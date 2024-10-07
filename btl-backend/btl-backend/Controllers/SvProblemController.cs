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

    // gv controler
    [HttpPost("{classid}/add")]
    public IActionResult AddProblemToClass(int gvid, int classid, Problem problem)
    {
        return Ok();
    }

    [HttpDelete("{classid}/remove")]
    public IActionResult RemoveProblemFromClass(int gvid, int classid, int problemid)
    {
        return Ok();
    }

    [HttpGet("{classid}/problems")]
    public IActionResult GetProblemsInClass(int gvid, int classid)
    {
        return Ok();
    }

    [HttpGet("submissions")]
    public IActionResult GetSubmissions(int gvid)
    {
        return Ok();
    }

    [HttpGet("submissions/{classid}/{userid}")]
    public IActionResult GetSubmissionsOfStudentInClass(int gvid, int classid, int userid)
    {
        return Ok();
    }

    [HttpGet("submissions/{classid}")]
    public IActionResult GetSubmissionsInClass(int gvid, int classid)
    {
        return Ok();
    }

    // Admin controler
    // [HttpPost()]
    // public IActionResult CreateProblem(int userId, Problem problem)
    // {
    //     return Ok();
    // }
    //
    // [HttpDelete("{problemId}")]
    // public IActionResult DeleteProblem(int userId, int problemId)
    // {
    //     return Ok();
    // }
    //
    // [HttpPut("{problemId}")]
    // public IActionResult UpdateProblem(int userId, int problemId, Problem problem)
    // {
    //     return Ok();
    // }


}