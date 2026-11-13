using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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

        public async Task<List<Service>> GetAllAsync()
        {
            var services = await _context.Services.ToListAsync();
            return services;
        }

        public async Task<Service?> GetByIdAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null) return null;

            return service;
        }

        public async Task<List<Service>> GetByTitleAsync(string title)
        {
            var services = await _context.Services
                .Where(s => s.Title.Contains(title))
                .ToListAsync();

            return services;
        } 

        public async Task<Service?> AddAsync(Service service)
        {
            _context.Services.Add(service);
            return service;
        }

        public async Task<Service?> UpdateAsync(Service service)
        {
            if (service == null)
                return service;

            _context.Services.Update(service);
            return service;
        }

        public async Task<Service?> DeleteAsync(int id)
        {
            var service = await GetByIdAsync(id);
            if (service == null) 
                return null;

            _context.Services.Remove(service);
            return service;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
