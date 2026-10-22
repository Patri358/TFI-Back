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

        public List <Pet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pet GetByClientId(int clientId)
        {
            throw new NotImplementedException();
        }

        public Pet GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Pet Add(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet Update(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet? Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
