using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Persistences;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infraestructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public async Task  <List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
