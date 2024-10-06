namespace btl_backend.Dtos;

public class ProblemDto
{
    public int ProblemId { get; set; }

    public string? Status { get; set; }

    public string? ProblemTitle { get; set; }

    public int Difficulty { get; set; }
}