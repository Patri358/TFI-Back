using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IShiftRepository : IRepository<Shift>
    {
        Task<IEnumerable<Shift>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<Shift>> GetByVeterinaryIdAsync(int veterinaryId);
        Task<IEnumerable<Shift>> GetByPetIdAsync(int petId);
        Task<IEnumerable<Shift>> GetByStatusAsync(string status);
    }
}
