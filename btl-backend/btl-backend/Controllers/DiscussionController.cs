using btl_backend.Models;
using btl_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace btl_backend.Controllers;

[ApiController]
[Route("api/discussion")]
public class DiscussionController : ControllerBase
{
    private readonly DiscussionService _discussionService;

    public DiscussionController(DiscussionService discussionService)
    {
        _discussionService = discussionService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetListDiscussions()
    {
        var discussions = await _discussionService.GetListDiscussions();
        return Ok(discussions);
    }

    [HttpGet("{discussionid}")]
    public async Task<IActionResult> GetDiscussion(int discussionid)
    {
        var discussion = await _discussionService.GetDiscussion(discussionid);
        if (discussion == null) return NotFound();
        return Ok(discussion);
    }

    [HttpPost("{classid}/create")]
    public async Task<IActionResult> CreateDiscussion(Discussion discussion)
    {
        if (discussion.Title == null || discussion.Content == null || discussion.AuthorId == 0)
        {
            return BadRequest(new {message = "Invalid Discussion"});
        }
        var succeed = await _discussionService.CreateDiscussion(discussion);
        if (!succeed) return BadRequest(new {message = "Invalid Discussion"});
        return Ok();
    }

    [HttpDelete("{discussionid}/delete")]
    public async Task<IActionResult> DeleteDiscussion(int discussionid)
    {
        var succeed = await _discussionService.DeleteDiscussion(discussionid);
        if (!succeed) return NotFound();
        return Ok();
    }
}