using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        //Task<Session?> GetByTokenAsync(string token);
        //Task<IEnumerable<Session>> GetActiveSessionsByUserIdAsync(int userId);
    }
}