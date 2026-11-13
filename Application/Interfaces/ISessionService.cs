using Application.Models.Session;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISessionService
    {
        Task<List<SessionDTO>> GetAllAsync();
        Task<SessionDTO?> GetByIdAsync(int id);
        Task<SessionDTO?> GetByTokenAsync(string token);
        Task<List<SessionDTO>> GetActiveSessionsByUserIdAsync(int userId);
        Task<SessionDTO?> AddAsync(CreateSessionDTO session);
        Task<SessionDTO?> UpdateAsync(SessionDTO session);
        Task<SessionDTO?> DeleteAsync(int id);
    }
}