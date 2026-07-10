using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Models.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
}