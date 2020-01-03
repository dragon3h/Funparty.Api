using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Funparty.Api.Application.Common.Exceptions;
using Funparty.Api.Application.Dtos;
using Funparty.Api.Application.Interfaces;
using Funparty.Api.Domain.Entities;using Microsoft.EntityFrameworkCore;

namespace Funparty.Api.Persistence.Repositories
{
    public class MascotRepository : IMascotRepository
    {
        private readonly FunpartyDbContext _context;
        private readonly IMapper _mapper;

        public MascotRepository(FunpartyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ICollection<Mascot>> GetAllMascots()
        {
            var mascots = await _context.Mascots.Include(p => p.MascotPhotos).ToListAsync();
            return mascots;
        }

        public async Task<Mascot> GetMascotById(int id)
        {
            var mascot = await _context.Mascots.Include(p => p.MascotPhotos).FirstOrDefaultAsync(m => m.Id == id);
            return mascot;
        }

        public async Task<Mascot> CreateMascot(Mascot mascot)
        {
            var isExist = await MascotExist(mascot.Id);
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

        public async Task<bool> MascotExist(int id)
        {
            var mascot = await _context.Mascots.FirstOrDefaultAsync(m => m.Id == id);

            return mascot != null;
        }

        public async Task<int> DeleteMascot(int id)
        {
            var mascotToDelete = await GetMascotById(id);

            if (mascotToDelete == null)
            {
                throw new NotFoundException(nameof(Mascot), id);
            }

            _context.Mascots.Remove(mascotToDelete);
             await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Mascot> EditMascot(MascotDto mascot)
        {
            var mascotToEdit = await GetMascotById(mascot.Id);

            if (mascotToEdit == null)
            {
                throw new NotFoundException(nameof(Mascot), mascot.Id);
            }

            mascotToEdit.Category = mascot.Category;
            mascotToEdit.MascotPhotos = _mapper.Map<ICollection<MascotPhoto>>(mascot.MascotPhotos);
            mascotToEdit.Name = mascot.Name;
            mascotToEdit.RentPrice = mascot.RentPrice;
            mascotToEdit.SalePrice = mascot.SalePrice;
            mascotToEdit.UpdatedDate = new DateTime();

            await _context.SaveChangesAsync();

            return mascotToEdit;
        }
    }
}