using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ApplicationDbContext _context;
        public ShiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Shift>> GetAllAsync()
        {
            return await _context.Shifts.ToListAsync();
        }
        public async Task<Shift?> GetByIdAsync(int id)
        {
            var shift = await _context.Shifts.FirstOrDefaultAsync(s => s.Id == id);
            return shift;
        }

        public async Task<List<Shift>> GetByClientIdAsync(int clientId)
        {
            return await _context.Shifts.Where(s => s.ClientId == clientId).ToListAsync();
        }

        public async Task<List<Shift>> GetByVeterinaryIdAsync(int vetId)
        {
            return await _context.Shifts.Where(s => s.VeterinaryId == vetId).ToListAsync();
        }

        public async Task<List<Shift>> GetByPetIdAsync(int petId)
        {
            return await _context.Shifts.Where(s => s.PetId == petId).ToListAsync();
        }
        public async Task<List<Shift>> GetByStatusAsync(ShiftStatus status)
        {
            return await _context.Shifts.Where(s => s.Status == status).ToListAsync();
        }

        public async Task<Shift?> AddAsync(Shift shift)
        {
            if (shift == null) return null;

            _context.Shifts.Add(shift);
            return shift;
        }

        public async Task<Shift?> UpdateAsync(Shift shift)
        {
            _context.Shifts.Update(shift);
            return shift;
        }

        public async Task<Shift?> DeleteAsync(int id)
        {
            var shift = await GetByIdAsync(id);
            if (shift == null) return null;

            _context.Shifts.Remove(shift);
            return shift;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}