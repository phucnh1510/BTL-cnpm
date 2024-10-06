using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class Problem
{
    public int ProblemId { get; set; }

    [Required]
    [StringLength(100)]
    public string? ProblemName { get; set; }

    [Required]
    [MaxLength(100)]
    public string? ProblemContent { get; set; }

    public int Difficulty { get; set; }

    public List<Class>? Classes { get; set; }

    public List<Submission> Submissions { get; set; }

    public List<Topic>? Topics { get; set; }

    public List<string>? Code { get; set; }

    public List<TestCase>? TestCases { get; set; }
}