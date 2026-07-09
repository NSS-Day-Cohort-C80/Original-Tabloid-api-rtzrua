using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
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

    [HttpDelete("{id}")]
    //[Authorize]
    public IActionResult DeletePost(int id)
    {
        Post post = _dbContext.Posts.SingleOrDefault(p => p.Id == id);

        if (post == null)
        {
            return NotFound();
        }
        string identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        UserProfile currentUser = _dbContext.UserProfiles.SingleOrDefault(up => up.IdentityUserId == identityUserId);

        if (currentUser == null || post.UserProfileId != currentUser.Id)
        {
            return Forbid();
        }

        _dbContext.Posts.Remove(post);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetPostDetails(int id)
    {
        Post post = _dbContext.Posts
            .Include(p => p.UserProfile)
            .ThenInclude(up => up.IdentityUser)
            .SingleOrDefault(p => p.Id == id);

        if (post == null)
        {
            return NotFound();
        }

        PostDetailDTO postDetailDTO = _mapper.Map<PostDetailDTO>(post);

        return Ok(postDetailDTO);
    }

    [HttpGet("byuser/{userProfileId}")]
    [Authorize]
    public IActionResult GetPostsByUser(int userProfileId)
    {
        List<Post> posts = _dbContext.Posts
            .Include(p => p.UserProfile)
            .Where(p => p.UserProfileId == userProfileId)
            .Where(p => p.PublicationDate <= DateTime.Now)
            .OrderByDescending(p => p.PublicationDate)
            .ToList();

        List<PostDTO> postDTOs = _mapper.Map<List<PostDTO>>(posts);

        return Ok(postDTOs);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreatePost(Post post)
    {
        var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = _dbContext.UserProfiles.SingleOrDefault(up => up.IdentityUserId == identityUserId);

        if (profile == null)
        {
            return NotFound();
        }

        post.isApproved = true;
        post.CreationDate = DateTime.Now;
        post.UserProfileId = profile.Id;

        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();

        return Created($"/api/post/{post.Id}", post);
    }
}
