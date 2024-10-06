using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class User
{
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Password { get; set; }

    public int Role { get; set; }

    public int ClassId { get; set; } // Foreign key property
    public Class? Class { get; set; } // Navigation property

    public List<Submission>? Submissions { get; set; }
}

internal enum Role
{
    Student = 0,
    Teacher = 1,
    Admin = 2
}