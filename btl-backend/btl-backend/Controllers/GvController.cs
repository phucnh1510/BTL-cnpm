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

    [HttpGet("{classid}/students")]
    public async Task<IActionResult> GetListStudentsInClass(int gvid, int classid)
    {
        var students = await _userService.GetListStudentsInClass(gvid, classid);
        return Ok(students);
    }

    [HttpGet("allclasses")]
    public async Task<IActionResult> GetClasses(int gvid)
    {
        var classes = await _userService.GetListClassAsync(gvid);
        return Ok(classes);
    }

    [HttpGet("{classid}/problemcount")]
    public async Task<IActionResult> GetClassProblemCount(int gv, int classid)
    {
        var problems = await _userService.GetClassProblemCountAsync(gv, classid);
        return Ok(problems);
    }

    [HttpGet("{classid}/problemset")]
    public async Task<IActionResult> GetClassProblemSet(int gvid, int classid)
    {
        var problems = await _userService.GetClassProblemSetAsync(gvid, classid);
        return Ok(problems);
    }

    [HttpPut("{classid}/{svId}/disable")]
    public async Task<IActionResult> DisableStudent(int gvid, int classid, int svId)
    {
        var succeed = await _userService.DisableStudentInClassAsync(gvid, classid, svId);
        if (!succeed) return NotFound();
        return Ok();
    }

    [HttpPut("{classid}/{svId}/enable")]
    public async Task<IActionResult> EnableStudent(int gvid, int classid, int svId)
    {
        var succeed = await _userService.EnableStudentInClassAsync(gvid, classid, svId);
        if (!succeed) return NotFound();
        return Ok();
    }
}