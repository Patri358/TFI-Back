using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
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

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            return user;
        }

        public User? Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return user;
        }

        // ASYNC 
        // ------------------------------------------------------------------------------------------------------------------------
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await Task.CompletedTask;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            return await Task.FromResult(user);
        }
    }
}
