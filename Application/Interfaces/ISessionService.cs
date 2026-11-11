using Application.Models.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISessionService
    {
        Task<List<SessionDTO>> GetAllAsync();
        Task<SessionDTO?> GetByIdAsync(int id);
        Task<SessionDTO> AddAsync(CreateSessionDTO session);
        Task<SessionDTO?> UpdateAsync(SessionDTO session);
        Task<SessionDTO?> DeleteAsync(int id);
    }
}