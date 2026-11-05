using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByNameAsync(string Name);
        Task<User?> GetByEmailAsync(string email);
    }
}