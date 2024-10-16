using btl_backend.Data;
using btl_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace btl_backend.Services;

public class DiscussionService
{
    private readonly AppDbContext _context;

    public DiscussionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Discussion>> GetListDiscussions()
    {
        var discussions = await _context.Discussions
            .Include(d => d.Author)
            .AsNoTracking()
            .ToListAsync();
        return discussions;
    }

    public async Task<bool> CreateDiscussion(Discussion discussion)
    {
        discussion.CreateTime = DateTime.UtcNow;
        await _context.Discussions.AddAsync(discussion);
        var succeed = await _context.SaveChangesAsync() > 0;
        return succeed;
    }

    public async Task<bool> DeleteDiscussion(int discussionid)
    {
        var discussion = await _context.Discussions.FindAsync(discussionid);
        if (discussion == null) return false;
        _context.Discussions.Remove(discussion);
        var succeed = await _context.SaveChangesAsync() > 0;
        return succeed;
    }

    public async Task<Discussion?> GetDiscussion(int discussionid)
    {
        var discussion = await _context.Discussions
            .Include(d => d.Author)
            .Include(d => d.Comments)
            .ThenInclude(c => c.Author)
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.DiscussionId == discussionid);
        return discussion;
    }
}