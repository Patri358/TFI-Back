using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;
        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> GetAllAsync()
        {
            var pets = await _context.Pets.ToListAsync();
            return pets;
        }

        //id de la mascota
        public async Task <Pet?> GetByIdAsync(int id)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
            return pet;
        }

        // id del dueño
        public async Task<List<Pet>> GetByClientIdAsync(int clientId)
        {
            var pet = await _context.Pets
                .Where(p => p.ClientId == clientId)
                .ToListAsync();
            return pet;
        }

        public async Task<Pet?> AddAsync(Pet pet)
        {
            _context.Pets.Add(pet);
            return pet;
        }

        public async Task<Pet?> UpdateAsync(Pet pet)
        {
            if (pet == null)
                return null;

            _context.Pets.Update(pet);
            return pet;
        }

        public async Task<Pet?> DeleteAsync(int id)
        {
            var pet = await GetByIdAsync(id);
            if (pet == null) return null;

            _context.Pets.Remove(pet);
            return pet;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}