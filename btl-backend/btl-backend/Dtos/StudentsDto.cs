namespace btl_backend.Dtos;

public class StudentsDto
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public bool Status { get; set; }

    public int ProblemCount { get; set; }
}