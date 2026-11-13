using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.Marshalling;

namespace Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;
        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Session>> GetAllAsync()
        {
            var sessions = await _context.Sessions.ToListAsync();
            return sessions;
        }

        public async Task<Session?> GetByIdAsync(int id)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.Id == id);
            if (session == null) return null;

            return session;
        }

        public async Task<Session?> GetByTokenAsync(string token)
        {
            var session = await _context.Sessions.FirstOrDefaultAsync(s => s.Token == token);
            return session;
        }

        public async Task<List<Session>> GetActiveSessionsByUserIdAsync(int userId)
        {
            var sessions = await _context.Sessions
                .Where(s => s.UserId == userId && s.RevocationDate > DateTime.Now)
                .ToListAsync();

            return sessions;
        }

        public async Task<Session?> AddAsync(Session session)
        {
            _context.Sessions.Add(session);
            return session;
        }

        public async Task<Session?> UpdateAsync(Session session)
        {
            if (session == null)
                return null;

            _context.Sessions.Update(session);
            return session;
        }

        public async Task<Session?> DeleteAsync(int id)
        {
            var session = await GetByIdAsync(id);
            if (session == null) 
                return null;

            _context.Sessions.Remove(session);
            return session;
        }
        
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
