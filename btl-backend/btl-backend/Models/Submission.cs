namespace btl_backend.Models;

public class Submission
{
    public string? SubmissionID { get; set; }

    public string? ProblemID { get; set; }

    public string? UserID { get; set; }

    public string? Status { get; set; }

    public string? Language { get; set; }

    public string? Code { get; set; }

    public int SubmissionCount { get; set; }

    public DateTime SubmissionTime { get; set; }

    public decimal ExecutionTime { get; set; }

    public decimal Memory { get; set; }

    public string? Note { get; set; }
}