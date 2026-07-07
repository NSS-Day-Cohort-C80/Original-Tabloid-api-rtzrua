using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PostId { get; set; }
}