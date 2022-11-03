namespace EF_Core_Load_Related_Data.Api.Data;

public class SuperHero
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TeamId { get; set; }
}
