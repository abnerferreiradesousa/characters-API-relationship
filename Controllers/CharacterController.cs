using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreRelationshipsTutorial.Protocols;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        public DataContext _context { get; set; }
        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(c => c.UserId == userId)
                .Include(c => c.Weapon)
                .ToListAsync();

            return characters;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacter request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if(user == null)
                return NotFound();

            var character = new Character {
                Name = request.Name,
                RpgClass = request.RpgClass,
                User = user,
            };

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return await Get(character.UserId);
        }

        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> AddWeapon(CreateWeapon request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if(character == null)
                return NotFound();

            var weapon = new Weapon {
                Name = request.Name,
                Damage = request.Damage,
                Character = character
            };

            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();

            return character;
        }

        [HttpPost("skill")]
        public async Task<ActionResult<Character>> AddCharacterSkill(CreateCharacterSkill request)
        {
            var character = await _context.Characters
                .Where(c => c.Id == request.CharacterId)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync();
                
            if(character == null)
                return NotFound();

            var skill = await _context.Skills.FindAsync(request.SkillId);
            if(skill == null)
                return NotFound();

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}