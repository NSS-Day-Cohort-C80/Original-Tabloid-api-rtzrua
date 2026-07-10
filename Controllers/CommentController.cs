using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly TabloidDbContext _dbContext;
    private readonly IMapper _mapper;

    public CommentController(TabloidDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet("byPost/{postId}")]
    [Authorize]
    public IActionResult GetCommentsByPost(int postId)
    {
        List<Comment> comments = _dbContext.Comments
            .Include(c => c.UserProfile)
            .Where(c => c.PostId == postId)
            .OrderByDescending(c => c.CreationDate)
            .ToList();

        List<CommentDTO> commentDTOs = _mapper.Map<List<CommentDTO>>(comments);

        return Ok(commentDTOs);
    }
}