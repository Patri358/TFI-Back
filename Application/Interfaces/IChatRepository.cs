using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<IEnumerable<Chat>> GetByClientIdAsync(int clientId);
        Task<IEnumerable<Chat>> GetByRecepcionistIdAsync(int recepcionistId);
    }
}
