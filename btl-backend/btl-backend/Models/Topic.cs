using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class Topic
{
    public int TopicId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? TopicName { get; set; }

    public int ProblemId { get; set; } // Foreign key property

    public List<Problem>? Problems { get; set; } // Navigation property

}