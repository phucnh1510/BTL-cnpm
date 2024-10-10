using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class Problem
{
    public int ProblemId { get; set; }

    [Required]
    [StringLength(100)]
    public string? Title { get; set; }

    [Required]
    [MaxLength(10000)]
    public string? Description { get; set; }

    public int Difficulty { get; set; }

    public bool Solution { get; set; }

    public List<string> TestCode { get; set; } = [];

    public List<string> TemplateCode { get; set; } = [];

    public List<Class>? Classes { get; set; }

    public List<Submission>? Submissions { get; set; }

    public List<Topic>? Topics { get; set; }

}