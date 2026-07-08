using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tabloid.Data;
using Tabloid.Models;
using Tabloid.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace Tabloid.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TabloidController : ControllerBase
{
    private TabloidDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserProfileController(TabloidDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    // Add your controllers here
    
}