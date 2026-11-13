using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<List<Rating>> GetByClientIdAsync(int clientId);
        Task<List<Rating>> GetByShiftIdAsync(int shiftId);
    }
}