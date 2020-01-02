using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Funparty.Api.Application.Dtos;
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
        private readonly IMapper _mapper;

        public MascotController(IMascotRepository mascotRepository, IMapper mapper)
        {
            _mascotRepository = mascotRepository;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> GetMascots()
        {
            var mascots = await _mascotRepository.GetAllMascots();

            var mascotsToReturn = _mapper.Map<IEnumerable<MascotDto>>(mascots);
            return Ok(mascotsToReturn);
        }

        // GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMascotById(int id)
        {
            var mascot = await _mascotRepository.GetMascotById(id);
            return Ok(mascot);
        }

        // POST
        [HttpPost("create")]
        public async Task<IActionResult> CreateMascot(MascotDto mascot)
        {
            var mascotToCreate = _mapper.Map<Mascot>(mascot);
            var newMascot = await _mascotRepository.CreateMascot(mascotToCreate);
            var createdMascot = _mapper.Map<MascotDto>(newMascot);

            return Ok(createdMascot);
        }
    }
}