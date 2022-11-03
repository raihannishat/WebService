using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationships.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
	private readonly DataContext _dataContext;

	public CharacterController(DataContext dataContext)
	{
		_dataContext = dataContext;
	}

	[HttpGet]
	public async Task<ActionResult<List<Character>>> Get(int userId)
	{
		var character = await _dataContext.Character!
			.Where(c => c.UserId == userId)
			.Include(c => c.Weapon)
			.Include(c => c.Skills)
			.ToListAsync();

		return Ok(character);
	}

	[HttpPost]
	public async Task<ActionResult<List<Character>>> Create(CreateCharacterDto request)
	{
		var user = await _dataContext.User!.FindAsync(request.UserId);

		if (user == null) return NotFound();

		var newCharacter = new Character
		{
			Name = request.Name,
			RpgClass = request.RpgClass,
			User = user,
		};

		_dataContext.Character!.Add(newCharacter);
		await _dataContext.SaveChangesAsync();

		return await Get(newCharacter.UserId);
	}

	[HttpPost("Weapon")]
	public async Task<ActionResult<Character>> CreateWeapon(CreateWeaponDto request)
	{
		var character = await _dataContext.Character!.FindAsync(request.CharacterId);

		if (character == null) return NotFound();

		var newWeapon = new Weapon
		{
			Name = request.Name,
			Damage = request.Damage,
			Character = character
		};

		_dataContext.Weapon!.Add(newWeapon);
		await _dataContext.SaveChangesAsync();

		return character;
	}

	[HttpPost("skill")]
	public async Task<ActionResult<Character>> CreateCharacterSkill(CreateCharacterSkillDto request)
	{
		var character = await _dataContext.Character!
			.Where(c => c.Id == request.CharacterId)
			.Include(c => c.Skills)
			.FirstOrDefaultAsync();

		if (character == null) return NotFound();

		var skill = await _dataContext.Skill!.FindAsync(request.SkillId);
		if (character == null) return NotFound();

		character.Skills!.Add(skill!);
		await _dataContext.SaveChangesAsync();

		return character;
	}
}