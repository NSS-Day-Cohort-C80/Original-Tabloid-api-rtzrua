namespace Tabloid.Models.DTOs;

public class CommentDTO
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public int PostId { get; set; }
    public string AuthorDisplayName { get; set; }
}