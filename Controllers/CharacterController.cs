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
    [Route("api/[controller]")]
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
                .Where<Character>(c => c.UserId == userId)
                .ToListAsync();
                
            return Ok(characters);
        }
    }
}