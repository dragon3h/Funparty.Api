using System.Threading.Tasks;
using Funparty.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Funparty.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MascotController : ControllerBase
    {
        private readonly FunpartyDbContext _context;

        public MascotController(FunpartyDbContext context)
        {
            _context = context;
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> GetMascots()
        {
            var mascots = await _context.Mascots.ToListAsync();
            return Ok(mascots);
        }
    }
}