namespace btl_backend.Dtos;

public class SubmissionDto
{
    public int ProblemId { get; set; }

    public int UserId { get; set; }

    public int Language { get; set; }

    public string Code { get; set; } = "";
}