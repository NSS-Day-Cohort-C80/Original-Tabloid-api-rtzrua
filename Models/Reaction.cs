using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Models;

public class Reaction
{
    public int Id { get; set; }
    [Required]
    public string Emoji { get; set; }
    public int UserProfileId { get; set; }
    public int PostId { get; set; }

    public UserProfile UserProfile { get; set; }
    public Post Post { get; set; }
}