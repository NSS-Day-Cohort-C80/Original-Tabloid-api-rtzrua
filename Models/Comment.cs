using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models;

public class Comment
{
    public int Id { get; set; }
    [Required]
    public string Subject { get; set; }
    [Required]
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public int PostId { get; set; }
    public int UserProfileId { get; set; }

    public Post Post { get; set; }
    public UserProfile UserProfile { get; set; }

}