using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

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
            var sessions = _context.Sessions.ToList();
            return sessions;
        }

        public Session? GetById(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (session == null) return null;

            return session;
        }

        public Session Add(Session session)
        {
            _context.Sessions.Add(session);
            return session;
        }

        public Session Update(Session session)
        {
            _context.Sessions.Update(session);
            return session;
        }

        public Session? Delete(int id)
        {
            var session = GetById(id);
            if (session == null) return null;

            _context.Sessions.Remove(session);
            return session;
        }
    }
}
