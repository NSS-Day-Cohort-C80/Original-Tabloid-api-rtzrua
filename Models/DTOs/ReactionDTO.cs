namespace Tabloid.Models.DTOs;

public class ReactionDTO
{
    public int Id { get; set; }
    public string Emoji { get; set; }
    public int UserProfileId { get; set; }
    public int PostId { get; set; }
}