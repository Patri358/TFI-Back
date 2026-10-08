using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
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
            return _context.User.ToList();
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task AddAsync(User entity)
        {
            await _context.User.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public void Update(User entity)
        {
            _context.User.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(User entity)
        {
            _context.User.Remove(entity);
            _context.SaveChanges();
        }
    }
}
