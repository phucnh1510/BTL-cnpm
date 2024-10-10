using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/gv")]
public class GvController : ControllerBase
{
    private readonly UserService _userService;

    public GvController(UserService userService)
    {
        _userService = userService;
    }

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

    [HttpGet("{classid}/{userid}/submissions")]
    public IActionResult GetSubmissionsOfStudentInClass(int gvid, int classid, int userid)
    {
        return Ok();
    }

    [HttpGet("{classid}/submissions")]
    public IActionResult GetSubmissionsInClass(int gvid, int classid)
    {
        return Ok();
    }
}