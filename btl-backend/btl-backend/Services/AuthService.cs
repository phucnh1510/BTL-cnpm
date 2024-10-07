using btl_backend.Data;

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

    public int GetUserId(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username)?.UserId ?? -1;
    }
}