using btl_backend.Data;
using btl_backend.Models;

namespace btl_backend.Services;

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public bool Authenticate(string username, string password)
    {
        return _context.Users.Any(u => u.Username == username && u.Password == password);
    }

    public (int userId, int userRole) GetUserId(string username)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        return (user?.UserId ?? -1, user?.UserRole ?? (int) Role.Unknown);
    }

    public bool Register(User user)
    {
        return false;
    }

    public bool Delete(int userid)
    {
        return false;
    }
}