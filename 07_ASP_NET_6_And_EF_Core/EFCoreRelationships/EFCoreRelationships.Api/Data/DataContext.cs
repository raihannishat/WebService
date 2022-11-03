namespace EFCoreRelationships.Api.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{

	}

	public DbSet<User>? User { get; set; }
	public DbSet<Character>? Character { get; set; }
	public DbSet<Weapon>? Weapon { get; set; }
	public DbSet<Skill>? Skill { get; set; }
}
