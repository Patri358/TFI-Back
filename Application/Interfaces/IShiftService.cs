using Application.Models.Shift;
using Application.Models.ShiftEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IShiftService
    {
        public Task<List<ShiftDTO>> GetAllAsync();
        public Task<ShiftDTO?> GetByIdAsync(int id);
        public Task<ShiftDTO?> AddAsync(CreateShiftDTO shift, CreateShiftEventDTO shiftEvent);
        public Task<ShiftDTO?> UpdateAsync(ShiftDTO shift, CreateShiftEventDTO shiftEvent);
        public Task<ShiftDTO?> DeleteAsync(int id);
    }
}