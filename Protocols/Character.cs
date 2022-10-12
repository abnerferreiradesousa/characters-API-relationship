using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EFCoreRelationshipsTutorial.Protocols
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public Weapon Weapon { get; set; }
    }
}