using Domain.Entities;
using Application.Models.ShiftEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IShiftEventService
    {
        public Task<List<ShiftEventDTO>> GetByShiftIdAsync(int shiftId);
        public Task<List<ShiftEventDTO>> GetByUserIdAsync(int userId);
    }
}