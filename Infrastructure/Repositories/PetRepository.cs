using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;
        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Pet> GetAll()
        {
            return _context.Pets;
        }

        //id de la mascota
        public Pet? GetById(int id)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.Id == id);
            return pet;
        }

        // id del dueño
        public Pet? GetByClientId(int clientId)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.ClientId == clientId);
            return pet;
        }

        public Pet Add(Pet pet)
        {
            _context.Pets.Add(pet);
            return pet;
        }

        public Pet Update(Pet pet)
        {
            var index = _context.Pets.FindIndex(p => p.Id == pet.Id);

            if (index == -1) return pet;

            _context.Pets[index] = pet;
            return pet;
        }

        public Pet? Delete(int id)
        {
            var pet = GetById(id);

            if (pet == null) return null;
            
            _context.Pets.Remove(pet);
            return pet;
        }
    }
}