using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface ISesionRepository : IRepository<Sesion>
    {
        Task<Sesion?> GetByTokenAsync(string token);
        Task<IEnumerable<Sesion>> GetActiveSessionsByUserIdAsync(int userId);
    }
}
