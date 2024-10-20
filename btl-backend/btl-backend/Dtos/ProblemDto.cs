namespace btl_backend.Dtos;

public class ProblemDto
{
    public int ProblemId { get; set; }

    public int Status { get; set; }

    public bool Solution { get; set; }

    public string? Title { get; set; }

    public int Difficulty { get; set; }
}