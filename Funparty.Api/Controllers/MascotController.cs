using System.Threading.Tasks;
using Funparty.Api.Application.Interfaces;
using Funparty.Api.Domain.Entities;
using Funparty.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Funparty.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MascotController : ControllerBase
    {
        private readonly IMascotRepository _mascotRepository;

        public MascotController(IMascotRepository mascotRepository)
        {
            _mascotRepository = mascotRepository;
        }
        
        // GET
        [HttpGet]
        public async Task<IActionResult> GetMascots()
        {
            var mascots = await _mascotRepository.GetAllMascots();
            return Ok(mascots);
        }
        
        // POST
        [HttpPost("create")]
        public async Task<IActionResult> CreateMascot(Mascot mascot)
        {
            var newMascot = await _mascotRepository.CreateMascot(mascot);
            return Ok(newMascot);
        }
    }
}