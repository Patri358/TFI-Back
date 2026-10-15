using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IShiftEventRepository : IRepository<ShiftEvent>
    {
        Task<IEnumerable<ShiftEvent>> GetByShiftIdAsync(int shiftId);
        Task<IEnumerable<ShiftEvent>> GetByUserIdAsync(int userId);
    }
}
