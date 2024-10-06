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

    [Required]
    [MaxLength(100)]
    public string? ClassId { get; set; }

    public int Role { get; set; }

    public ICollection<Submission>? Submissions { get; set; }
}