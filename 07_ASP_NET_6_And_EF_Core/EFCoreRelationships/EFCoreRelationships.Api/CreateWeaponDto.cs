namespace EFCoreRelationships.Api;

public class CreateWeaponDto
{
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
    public int CharacterId { get; set; }
}
