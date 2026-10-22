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
            return _context.Users;
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

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            return await Task.FromResult(user);
        }


        public User Add(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await Task.CompletedTask;
        }


        public User Update(User user)
        {
            var index = _context.Users.FindIndex(u => u.Id == user.Id);

            if (index == -1)
            {
                return user;
            }

            _context.Users[index] = user;
            return user;
        }

        public User? Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return user;
        }

        //public async Task<List<User>> GetAllAsync()
        //{
        //    return await _context.User.ToListAsync();
        //}

        //public async Task<User?> GetByIdAsync(int id)
        //{
        //    return await _context.User.FindAsync(id);
        //}

        //public async Task AddAsync(User entity)
        //{
        //    await _context.User.AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //}
        //public void Update(User entity)
        //{
        //    _context.User.Update(entity);
        //    _context.SaveChanges();
        //}
        //public void Delete(User entity)
        //{
        //    _context.User.Remove(entity);
        //    _context.SaveChanges();
        //}
    }
}
