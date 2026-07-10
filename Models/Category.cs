using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Tabloid.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}