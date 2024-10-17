using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace btl_backend.Models;

public class Comment
{
    public int CommentId { get; set; }

    public int DiscussionId { get; set; }

    [Required]
    public int AuthorId { get; set; }

    [Required]
    [MaxLength(10000)]
    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public User? Author { get; set; }

    [JsonIgnore]
    public Discussion? Discussion { get; set; }
}