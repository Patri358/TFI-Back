using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IShiftRepository : IRepository<Shift>
    {
        Task<List<Shift>> GetByClientIdAsync(int clientId);
        Task<List<Shift>> GetByVeterinaryIdAsync(int veterinaryId);
        Task<List<Shift>> GetByPetIdAsync(int petId);
        Task<List<Shift>> GetByStatusAsync(ShiftStatus status);
    }
}