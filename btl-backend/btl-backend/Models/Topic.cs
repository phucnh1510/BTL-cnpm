using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace btl_backend.Models;

public class Topic
{
    public int TopicId { get; set; }

    [Required]
    [MaxLength(100)]
    public string? TopicName { get; set; }

    [JsonIgnore]
    public List<Problem>? Problems { get; set; } // Navigation property

}