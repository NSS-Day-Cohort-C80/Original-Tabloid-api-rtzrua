using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Tabloid.Models.DTOs;

public class PostDTO
{
    public int Id { get; set;}
    public string Title { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
    public string ImageLocation { get; set; }
    public DateTime PublicationDate { get; set;}
    public int UserProfileId { get; set; }
    public int TagId { get; set; }
    public int ReactionId { get; set; }  
}