using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funparty.Api.Application.Interfaces;
using Funparty.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Funparty.Api.Persistence.Repositories
{
    public class MascotRepository : IMascotRepository
    {
        private readonly FunpartyDbContext _context;

        public MascotRepository(FunpartyDbContext context)
        {
            _context = context;
        }
        
        public async Task<ICollection<Mascot>> GetAllMascots()
        {
            var mascots = await _context.Mascots.ToListAsync();
            return mascots;
        }

        public async Task<Mascot> GetMascotById(int id)
        {
            var mascot = await _context.Mascots.FirstOrDefaultAsync(m => m.Id == id);
            return mascot;
        }

        public async Task<Mascot> CreateMascot(Mascot mascot)
        {
            var isExist = await _context.Mascots.AnyAsync();
            if (!isExist)
            {
                await _context.AddAsync(mascot);
                await _context.SaveChangesAsync();
            }
            else
            {
                mascot = new Mascot();
            }

            return mascot;
        }

        public Task<bool> MascotExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteMascot(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}