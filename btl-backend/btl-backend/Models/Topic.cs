using System.ComponentModel.DataAnnotations;
namespace btl_backend.Models;

public class Topic
{
    public int TopicID { get; set; }

    [Required]
    [MaxLength(100)]
    public string? TopicName { get; set; }

    [Required]
    [MaxLength(100)]
    public string? TopicContent { get; set; }

}