using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
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
