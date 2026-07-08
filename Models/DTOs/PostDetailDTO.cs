namespace Tabloid.Models.DTOs;

public class PostDetailDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageLocation { get; set; }
    public string Content { get; set; }
    public DateTime PublicationDate { get; set; }
    public string AuthorUserName { get; set; }
}