using btl_backend.Data;
using btl_backend.Dtos;
using btl_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace btl_backend.Services;

public class UserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProblemDto>> GetProblemSet(int userId)
    {
        var problems = await _context.Users
            .Where(u => u.UserId == userId)
            .Select(u => u.Class)
            .SelectMany(c => c.Problems)
            .AsNoTracking()
            .GroupJoin(
                _context.Submissions,
                problem => problem.ProblemId,
                submission => submission.ProblemId,
                (problem, submissions) => new { problem, submissions }
            )
            .SelectMany(
                ps => ps.submissions.DefaultIfEmpty(),
                (ps, submission) => new ProblemDto
                {
                    ProblemId = ps.problem.ProblemId,
                    Title = ps.problem.Title,
                    Difficulty = ps.problem.Difficulty,
                    Status = submission != null ? submission.Status : null
                }
            )
            .ToListAsync();

        return problems;
    }

    public Problem? GetProblem(int userId, int problemId)
    {
        var problem = _context.Users
            .Where(u => u.UserId == userId)
            .Select(u => u.Class)
            .SelectMany(c => c.Problems)
            .Include(p => p.Topics)
            .AsNoTracking()
            .FirstOrDefault(p => p.ProblemId == problemId);
        return problem;
    }

    public async Task<List<Submission>> GetUserSubmissions(int userId)
    {
        var submissions = await _context.Submissions
            .Where(s => s.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
        return submissions;
    }

    public async Task<List<Submission>> GetProblemSubmissions(int userId, int problemId)
    {
        var submissions = await _context.Submissions
            .Where(s => s.UserId == userId && s.ProblemId == problemId)
            .AsNoTracking()
            .ToListAsync();
        return submissions;
    }
}