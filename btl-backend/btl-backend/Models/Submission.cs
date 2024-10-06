using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class Submission
{
    public int SubmissionID { get; set; }


    public Problem? Problem { get; set; }

    public User? User { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Status { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Language { get; set; }

    [Required]
    [MaxLength(1000)]
    public string? Code { get; set; }

    public DateTime SubmissionTime { get; set; }

    public decimal ExecutionTime { get; set; }

    public decimal Memory { get; set; }
}