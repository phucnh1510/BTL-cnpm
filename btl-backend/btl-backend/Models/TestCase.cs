using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class TestCase
{
    public int TestCaseID { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Input { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Output { get; set; }
}