using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Tabloid.Models;

public class Post
{
    public int Id { get; set;}
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public string Category { get; set; }
    public string ImageLocation { get; set; }
    public DateTime PublicationDate { get; set;}
    public int UserProfileId { get; set; }
    public int TagId { get; set; }
    public int ReactionId { get; set; }  
    public UserProfile UserProfile { get; set; }
}