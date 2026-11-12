using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<List<Chat>> GetByClientIdAsync(int clientId);
        Task<List<Chat>> GetByRecepcionistIdAsync(int receptionistId);
    }
}