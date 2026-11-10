using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IShiftEventRepository
    {
        Task<List<ShiftEvent>> GetByShiftIdAsync(int shiftId);
        Task<List<ShiftEvent>> GetByUserIdAsync(int userId);
        Task<ShiftEvent?> AddAsync(ShiftEvent shiftEvent);
        Task SaveChangesAsync();
    }
}