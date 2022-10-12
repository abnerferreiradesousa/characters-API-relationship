
namespace EFCoreRelationshipsTutorial.Protocols
{
    public class CreateWeapon
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;
        public int CharacterId { get; set; }
    }
}