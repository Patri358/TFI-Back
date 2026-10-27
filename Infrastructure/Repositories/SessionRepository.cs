using Application.Interfaces;
using Infrastructure.Persistence;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;
        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Session> GetAll()
        {
            return _context.Sessions;
        }

        public Session? GetById(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (session == null) return null;

            return session;
        }

        public Session Add(Session Session)
        {
            _context.Sessions.Add(Session);
            return Session;
        }

        public Session Update(Session Session)
        {
            var index = _context.Sessions.FindIndex(s => s.Id == Session.Id);
            if (index == -1) return Session;

            _context.Sessions[index] = Session;
            return Session;
        }

        public Session? Delete(int id)
        {
            var Session = GetById(id);
            if (Session == null) return null;

            _context.Sessions.Remove(Session);
            return Session;
        }

    }
}
