using System.Collections;
using System.Threading.Tasks;
using Funparty.Api.Domain.Entities;
using Funparty.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Funparty.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FunpartyDbContext _context;

        public UserController(FunpartyDbContext context)
        {
            _context = context;
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}