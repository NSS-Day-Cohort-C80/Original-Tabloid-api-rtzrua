using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Tabloid.Models.DTOs;

public class PostTagDTO
{
    public int PostId { get; set; }
    public int TagId { get; set; }
}