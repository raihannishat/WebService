global using Microsoft.AspNetCore.Mvc;

namespace EF_Core_Load_Related_Data.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComicController : ControllerBase
{
	private readonly DataContext _context;

	public ComicController(DataContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<List<Comic>>> Get()
	{
		var comics = await _context.Comics!
			.Include(c => c.Teams)
			.ThenInclude(c => c.SuperHeroes)
			.ToListAsync();

		return Ok(comics);
	}
}
