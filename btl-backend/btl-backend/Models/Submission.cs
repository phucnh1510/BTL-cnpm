using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace btl_backend.Models;

public class Submission
{
    public int SubmissionId { get; set; }

    public int ProblemId { get; set; }


    public int UserId { get; set; }

    [JsonIgnore]
    public Problem? Problem { get; set; }

    [JsonIgnore]
    public User? User { get; set; }

    [Required]
    [MaxLength(1000)]
    public string? Result { get; set; }

    public int Status { get; set; }

    public int Language { get; set; }

    [Required]
    [MaxLength(10000)]
    public string? Code { get; set; }

    public DateTime SubmissionTime { get; set; }

    public decimal ExecutionTime { get; set; }

    public decimal Memory { get; set; }
}

public enum Statuses
{
    Accepted = 0,
    WrongAnswer = 1,
    TimeLimitExceeded = 2,
    MemoryLimitExceeded = 3,
    RuntimeError = 4,
    CompilationError = 5,
    NotImplemented = -1
}