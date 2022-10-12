using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreRelationshipsTutorial.Protocols;

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
    }
}