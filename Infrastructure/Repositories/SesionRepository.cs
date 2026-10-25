using Application.Interfaces;
using Infrastructure.Persistence;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class SesionRepository : ISesionRepository
    {
        private readonly ApplicationDbContext _context;
        public SesionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sesion> GetAll()
        {
            return _context.Sessions;
        }

        public Sesion? GetById(int id)
        {
            var session = _context.Sessions.FirstOrDefault(s => s.Id == id);
            if (session == null) return null;

            return session;
        }

        public Sesion Add(Sesion sesion)
        {
            _context.Sessions.Add(sesion);
            return sesion;
        }

        public Sesion Update(Sesion sesion)
        {
            var index = _context.Sessions.FindIndex(s => s.Id == sesion.Id);
            if (index == -1) return sesion;

            _context.Sessions[index] = sesion;
            return sesion;
        }

        public Sesion? Delete(int id)
        {
            var sesion = GetById(id);
            if (sesion == null) return null;

            _context.Sessions.Remove(sesion);
            return sesion;
        }

    }
}
