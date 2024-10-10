using System.ComponentModel.DataAnnotations;

namespace btl_backend.Models;

public class Class
{
    public int ClassId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? ClassName { get; set; }

    public List<Problem> Problems { get; set; } = [];

    public List<User>? Users { get; set; }
}