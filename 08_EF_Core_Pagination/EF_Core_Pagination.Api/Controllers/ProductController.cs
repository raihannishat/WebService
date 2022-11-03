using Microsoft.AspNetCore.Mvc;

namespace EF_Core_Pagination.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly DataContext _context;

	public ProductController(DataContext context)
	{
		_context = context;
	}

	[HttpGet("{page}")]
	public async Task<ActionResult<List<Product>>> Get(int page)
	{
		if (_context.Products == null) return NotFound();

		var pageResult = 3f;
		var pageCount = Math.Ceiling(_context.Products.Count() / pageResult);

		var products = await _context.Products
			.Skip((page - 1) * (int)pageResult)
			.Take((int)pageResult)
			.ToListAsync();

		var respons = new ProductRespons
		{
			Products = products,
			CurrentPage = page,
			Pages = (int)pageCount
		};

		return Ok(respons);
	}
}
