
namespace EFCoreRelationshipsTutorial.Protocols
{
    public class CreateCharacter
    {
       public int UserId { get; set; } = 1;
       public string Name { get; set; } = "Knight";
       public string RpgClass { get; set; } = "Character";
    }
}