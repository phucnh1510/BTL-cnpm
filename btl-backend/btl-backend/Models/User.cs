using System.Diagnostics.CodeAnalysis;

namespace btl_backend.Models;

public class User
{
    public string? UserID { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? ClassID { get; set; }

    public int Role { get; set; }

    public int Completed { get; set; }

}