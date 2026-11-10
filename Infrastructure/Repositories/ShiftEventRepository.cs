using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ShiftEventRepository : IShiftEventRepository
    {
        private readonly ApplicationDbContext _context;
        public ShiftEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShiftEvent>> GetByShiftIdAsync(int shiftId)
        {
            return await _context.ShiftEvents.Where(se => se.ShiftId == shiftId).ToListAsync();
        }

        public async Task<List<ShiftEvent>> GetByUserIdAsync(int userId)
        {
            return await _context.ShiftEvents.Where(se => se.UserId == userId).ToListAsync();
        }

        public async Task<ShiftEvent?> AddAsync(ShiftEvent shiftEvent)
        {
            if (shiftEvent == null) return null;

            _context.ShiftEvents.Add(shiftEvent);
            return shiftEvent;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}