using System.ComponentModel.DataAnnotations;

namespace btl_backend.Models;

public class Discussion
{
    public int DiscussionId { get; set; }

    [Required]
    public int AuthorId { get; set; }

    public User? Author { get; set; }

    [Required]
    [MaxLength(1000)]
    public string? Title { get; set; }

    [Required]
    [MaxLength(10000)]
    public string? Content { get; set; }

    public DateTime CreateTime { get; set; }

    public List<Comment> Comments { get; set; } = [];
}