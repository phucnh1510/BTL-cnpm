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

    public async Task<List<ProblemDto>> GetProblemSetAsync(int userId)
    {
        var problems = await _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Classes!)
            .SelectMany(c => c.Problems)
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
                    Status = submission != null ? submission.Status : -1
                }
            )
            .AsNoTracking()
            .ToListAsync();

        return problems;
    }

    public Problem? GetProblem(int userId, int problemId)
    {
        var problem = _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Classes!)
            .SelectMany(c => c.Problems)
            .Include(p => p.Topics)
            .AsNoTracking()
            .FirstOrDefault(p => p.ProblemId == problemId);
        return problem;
    }

    public async Task<List<Submission>> GetUserSubmissionsAsync(int userId)
    {
        var submissions = await _context.Submissions
            .Where(s => s.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
        return submissions;
    }

    public async Task<List<Submission>> GetProblemSubmissionsAsync(int userId, int problemId)
    {
        var submissions = await _context.Submissions
            .Where(s => s.UserId == userId && s.ProblemId == problemId)
            .AsNoTracking()
            .ToListAsync();
        return submissions;
    }

    public async Task<List<StudentsDto>> GetListStudentsInClassAsync(int userId, int classId)
    {
        var students = await _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Classes!)
            .Where(c => c.ClassId == classId)
            .SelectMany(c => c.Users!)
            .Where(u => u.UserRole == (int) Role.Student)
            .Select(
                s => new StudentsDto
            {
                UserId = s.UserId,
                Username = s.Username,
                Status = s.IsBlocked,
                ProblemCount = _context.Submissions
                    .Where(sub => sub.UserId == s.UserId && sub.Status == (int) Statuses.Accepted)
                    .Count()
            })
            .AsNoTracking()
            .ToListAsync();
        return students;
    }

    public async Task<List<Class>> GetUserClassAsync(int userId)
    {
        var classes = await _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Classes!)
            .AsNoTracking()
            .ToListAsync();
        return classes;
    }

    public async Task<int> GetClassProblemCountAsync(int userId, int classId)
    {
        var count = await _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Classes!)
            .Where(c => c.ClassId == classId)
            .SelectMany(c => c.Problems)
            .CountAsync();
        return count;
    }

    public async Task<List<Problem>> GetClassProblemSetAsync(int userId, int classId)
    {
        var problems = await _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Classes!)
            .Where(c => c.ClassId == classId)
            .SelectMany(c => c.Problems)
            .AsNoTracking()
            .ToListAsync();
        return problems;
    }

    public async Task<bool> DisableStudentInClassAsync(int gvId, int classId, int svId)
    {
        var student = await _context.Users
            .Where(u => u.UserId == gvId)
            .SelectMany(u => u.Classes!)
            .Where(c => c.ClassId == classId)
            .Where(c => c.Users != null)
            .SelectMany(c => c.Users!)
            .Where(u => u.UserId == svId)
            .FirstOrDefaultAsync();

        if (student == null) return false;

        student.IsBlocked = true;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> EnableStudentInClassAsync(int gvId, int classId, int svId)
    {
        var student = await _context.Users
            .Where(u => u.UserId == gvId)
            .SelectMany(u => u.Classes!)
            .Where(c => c.ClassId == classId)
            .SelectMany(c => c.Users!)
            .Where(u => u.UserId == svId)
            .FirstOrDefaultAsync();

        if (student == null) return false;

        student.IsBlocked = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        var sucess = await _context.SaveChangesAsync();
        return sucess > 0;
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        var student = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == userId);
        if (student == null) return false;
        _context.Users.Remove(student);
        var success = await _context.SaveChangesAsync();
        return success > 0;
    }

    public async Task<bool> AddProblemAsync(Problem problem)
    {
        await _context.Problems.AddAsync(problem);
        var success = await _context.SaveChangesAsync();
        return success > 0;
    }

    public async Task<bool> DeleteProblemAsync(int problemId)
    {
        var problem = await _context.Problems
            .FirstOrDefaultAsync(p => p.ProblemId == problemId);
        if (problem == null) return false;
        _context.Problems.Remove(problem);
        var success = await _context.SaveChangesAsync();
        return success > 0;
    }

    public async Task<List<StudentsDto>> GetClassRankingAsync(int userId, int classId)
    {
        var students = await _context.Users
            .Where(u => u.UserId == userId)
            .SelectMany(u => u.Classes!)
            .Where(c => c.ClassId == classId)
            .SelectMany(c => c.Users!)
            .Where(u => u.UserRole == (int) Role.Student)
            .Select(
                s => new StudentsDto
                {
                    UserId = s.UserId,
                    Username = s.Username,
                    Status = s.IsBlocked,
                    ProblemCount = _context.Submissions
                        .Where(sub => sub.UserId == s.UserId && sub.Status == (int) Statuses.Accepted)
                        .Count()
                })
            .OrderByDescending(s => s.ProblemCount)
            .AsNoTracking()
            .ToListAsync();
        return students;
    }

    internal async Task<List<Topic>> GetAllTopicsAsync()
    {
        var topics = await _context.Topics
            .AsNoTracking()
            .ToListAsync();
        return topics;
    }

    public async Task<List<Class>> GetAllClassesAsync()
    {
        var classes = await _context.Classes
            .AsNoTracking()
            .ToListAsync();
        return classes;
    }

    internal async Task<bool> AddClassAsync(Class @class)
    {
        await _context.Classes.AddAsync(@class);
        var success = await _context.SaveChangesAsync();
        return success > 0;
    }

    public async Task<bool> AddTopicAsync(Topic topic)
    {
        await _context.Topics.AddAsync(topic);
        var success = await _context.SaveChangesAsync();
        return success > 0;
    }

    public async Task<List<Problem>> GetAllProblemsAsync()
    {
        var problems = await _context.Problems
            .AsNoTracking()
            .ToListAsync();
        return problems;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await _context.Users
            .AsNoTracking()
            .ToListAsync();
        return users;
    }
}