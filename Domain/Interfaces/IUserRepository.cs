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
        User? GetByName(string Name);
        User? GetByEmail(string email);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task SaveChangesAsync();

    }
}