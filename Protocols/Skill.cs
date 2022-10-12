using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EFCoreRelationshipsTutorial.Protocols
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}