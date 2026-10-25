using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Service> GetAll()
        {
            return _context.Services;
        }

        public Service? GetById(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);
            if (service == null) return null;

            return service;
        }

        public Service Add(Service service)
        {
            _context.Services.Add(service);
            return service;
        }

        public Service Update(Service service)
        {
            var index = _context.Services.FindIndex(s => s.Id == service.Id);
            if (index == -1) return service;

            _context.Services[index] = service;
            return service;
        }

        public Service? Delete(int id)
        {
            var service = GetById(id);
            if (service == null) return null;

            _context.Services.Remove(service);
            return service;
        }

    }
}
