using Infrastructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ApiContexts context) : ControllerBase
{
    private readonly ApiContexts _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _context.Courses.ToListAsync();
        return Ok(courses);
    }
}
