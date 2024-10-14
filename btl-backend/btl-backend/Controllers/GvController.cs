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

    [HttpPut("{classid}/{userid}/disable")]
    public IActionResult DisableStudent(int gvid, int classid, int userid)
    {
        return Ok();
    }

    [HttpPut("{classid}/{userid}/enable")]
    public IActionResult EnableStudent(int gvid, int classid, int userid)
    {
        return Ok();
    }
}