using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private TabloidDbContext _dbContext;
    private readonly IMapper _mapper;

    public PostController(TabloidDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    // Add your controllers here
[HttpGet]
[Authorize]
    public IActionResult GetPosts()
    {
        List<Post> posts = _dbContext.Posts
            .Include(p => p.UserProfile)
            .Where(p => p.PublicationDate <= DateTime.Now)
            .OrderByDescending(p => p.PublicationDate)
            .ToList();

        List<PostDTO> postDTOs = _mapper.Map<List<PostDTO>>(posts);

        return Ok(postDTOs);
    }




}



