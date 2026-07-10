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
public class CategoryController : ControllerBase
{
    private readonly TabloidDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryController(TabloidDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetCategories()
    {
        List<Category> categories = _dbContext.Categories
            .OrderBy(c => c.Name)
            .ToList();

        List<CategoryDTO> categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);

        return Ok(categoryDTOs);
    }
}