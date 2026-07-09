using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Claims;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReactionController : ControllerBase
{
    private readonly TabloidDbContext _dbContext;
    private readonly IMapper _mapper;

    public ReactionController(TabloidDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddReaction(ReactionDTO reactionDTO)
    {
        string identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        UserProfile currentUser = _dbContext.UserProfiles.SingleOrDefault(up => up.IdentityUserId == identityUserId);

        if (currentUser == null)
        {
            return Unauthorized();
        }

        Reaction reaction = new Reaction
        {
            Emoji = reactionDTO.Emoji,
            PostId = reactionDTO.PostId,
            UserProfileId = currentUser.Id
        };

        _dbContext.Reactions.Add(reaction);
        _dbContext.SaveChanges();

        return Created($"/api/reaction/{reaction.Id}", _mapper.Map<ReactionDTO>(reaction));
    }

    [HttpGet("counts/{postId}")]
    public IActionResult GetReactionCounts(int postId)
    {
        var counts = _dbContext.Reactions
            .Where(r => r.PostId == postId)
            .GroupBy(r => r.Emoji)
            .Select(g => new
            {
                Emoji = g.Key,
                Count = g.Count()
            })
            .ToList();

        return Ok(counts);
    }
}