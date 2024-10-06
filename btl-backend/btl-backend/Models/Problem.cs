using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class Problem
{
    public int ProblemID { get; set; }

    [Required]
    [StringLength(100)]
    public string? ProblemName { get; set; }

    [Required]
    [MaxLength(100)]
    public string? ProblemContent { get; set; }

    public ICollection<Topic>? Topics { get; set; }

    public ICollection<string>? Code { get; set; }

    public ICollection<TestCase>? TestCases { get; set; }
}