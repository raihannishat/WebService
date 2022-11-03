using System.Text.Json.Serialization;

namespace EFCoreRelationships.Api;

public class Weapon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; } = 10;
    [JsonIgnore]
    public Character? Character { get; set; }
    public int characterId { get; set; }
}
