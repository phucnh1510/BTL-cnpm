using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class TestCase
{
    public int TestCaseId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Input { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Output { get; set; }

    public int ProblemId { get; set; } // Foreign key property
    public Problem? Problem { get; set; } // Navigation property
}