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

    [HttpPost("create")]
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
    public async Task<IActionResult> DeleteDiscussion(int userid, int discussionid)
    {
        var succeed = await _discussionService.DeleteDiscussion(userid, discussionid);
        if (!succeed) return BadRequest(new {message = "You are not the author of this discussion"});
        return Ok();
    }

    [HttpPost("{discussionid}/comment")]
    public async Task<IActionResult> CreateComment(int discussionid, Comment comment)
    {
        if (comment.Content == null || comment.AuthorId == 0)
        {
            return BadRequest(new {message = "Invalid Comment"});
        }
        var discussion = await _discussionService.GetDiscussion(discussionid);
        if (discussion == null) return NotFound();
        discussion.Comments.Add(comment);
        var succeed = await _discussionService.CreateDiscussion(discussion);
        if (!succeed) return BadRequest(new {message = "Invalid Comment"});
        return Ok();
    }

    [HttpDelete("{discussionid}/comment/{commentid}")]
    public async Task<IActionResult> DeleteComment(int userid, int discussionid, int commentid)
    {
        var discussion = await _discussionService.GetDiscussion(discussionid);
        if (discussion == null) return NotFound();
        var comment = discussion.Comments.FirstOrDefault(c => c.CommentId == commentid);
        if (comment == null) return NotFound();
        if (comment.AuthorId != userid) return BadRequest(new {message = "You are not the author of this comment"});
        discussion.Comments.Remove(comment);
        var succeed = await _discussionService.CreateDiscussion(discussion);
        if (!succeed) return BadRequest(new {message = "Invalid Comment"});
        return Ok();
    }
}