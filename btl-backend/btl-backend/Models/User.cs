using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

    public int UserRole { get; set; }

    public bool IsBlocked { get; set; }

    public List<Class>? Classes { get; set; }

    public List<Submission>? Submissions { get; set; }

    [JsonIgnore]
    public List<Discussion>? Discussions { get; set; }

    [JsonIgnore]
    public List<Comment>? Comments { get; set; }
}

internal enum Role
{
    Student = 0,
    Teacher = 1,
    Admin = 2,
    Unknown = -1
}