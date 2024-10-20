using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace btl_backend.Models;

public class Class
{
    public int ClassId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? ClassName { get; set; }

    [JsonIgnore]
    public List<Problem> Problems { get; set; } = [];

    [JsonIgnore]
    public List<User>? Users { get; set; }
}