using btl_backend.Data;
using btl_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace btl_backend.Services;

public class ProblemService
{
    private readonly AppDbContext _context;

    public ProblemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Problem>> GetProblems(int userId)
    {
        var problems = await _context.Users
            .Where(u => u.UserId == userId)
            .Select(u => u.Class)
            .SelectMany(c => c.Problems)
            .AsNoTracking()
            .ToListAsync();

        return problems;
    }
}