using Microsoft.AspNetCore.Mvc;

namespace SuperHero.Api.Controllers;
[ApiController, Route("api/[controller]")]
public class SuperHeroController : ControllerBase
{
    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("Get")]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        return Ok(await _context.SuperHeroes!.ToListAsync());
    }

    [HttpGet("Get{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
        var hero = await _context.SuperHeroes!.FindAsync(id);

        if (hero == null) return BadRequest("Hero not found!");

        return Ok(hero);
    }

    [HttpPost("Post")]
    public async Task<ActionResult<List<SuperHero>>> Post(SuperHero hero)
    {
        await _context.SuperHeroes!.AddAsync(hero);
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpPut("Put")]
    public async Task<ActionResult<List<SuperHero>>> Put(SuperHero request)
    {
        var dbHero = await _context.SuperHeroes!.FindAsync(request.Id);

        if (dbHero == null) return BadRequest("Hero not found!");

        dbHero.Name = request.Name;
        dbHero.FirstName = request.FirstName;
        dbHero.LastName = request.LastName;
        dbHero.Place = request.Place;

        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpDelete("Delete{id}")]
    public async Task<ActionResult<List<SuperHero>>> Delete(int id)
    {
        var dbHero = await _context.SuperHeroes!.FindAsync(id);

        if (dbHero == null) return BadRequest("Hero not found!");

        _context.SuperHeroes.Remove(dbHero);
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }
}
