using Application.Interfaces;
using Application.Models;
using Application.Models.Pet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<PetDTO> GetAll()
        {
            var pets = _petRepository.GetAll();

            return pets.Select(p => new PetDTO
            {
                Id = p.Id,
                ClientId = p.ClientId,
                Name = p.Name,
                Race = p.Race,
                Gender = p.Gender,
                Species = p.Species,
                BirthDate = p.BirthDate,
            }).ToList();
        }

        public PetDTO? GetById(int id)
        {
            var pet = _petRepository.GetById(id);

            if (pet == null) return null;

            return new PetDTO
            {
                Id = pet.Id,
                ClientId = pet.ClientId,
                Name = pet.Name,
                Race = pet.Race,
                Gender = pet.Gender,
                Species = pet.Species,
                BirthDate = pet.BirthDate,
            };
        }

        public PetDTO? GetByClientId(int clientId)
        {
            var pet = _petRepository.GetByClientId(clientId);

            if (pet == null) return null;

            return new PetDTO
            {
                Id = pet.Id,
                ClientId = pet.ClientId,
                Name = pet.Name,
                Race = pet.Race,
                Gender = pet.Gender,
                Species = pet.Species,
                BirthDate = pet.BirthDate,
            };
        }

        public PetDTO Add(CreatePetDTO pet)
        {
            var newPet = new PetDTO
            {
                Id = 3,
                ClientId = pet.ClientId,
                Name = pet.Name,
                Race = pet.Race,
                Gender = pet.Gender,
                Species = pet.Species,
                BirthDate = pet.BirthDate,
            };

            return newPet;
        }

        public PetDTO? Update(PetDTO pet)
        {
            var updatePet = _petRepository.GetById(pet.Id);

            if (updatePet == null) return null;
            
            updatePet.Id = pet.Id;
            updatePet.ClientId = pet.ClientId;
            updatePet.Name = pet.Name;
            updatePet.Race = pet.Race;
            updatePet.Gender = pet.Gender;
            updatePet.Species = pet.Species;
            updatePet.BirthDate = pet.BirthDate;

            return new PetDTO
            {
                Id = updatePet.Id,
                ClientId = updatePet.ClientId,
                Name = updatePet.Name,
                Race = updatePet.Race,
                Gender = updatePet.Gender,
                Species = updatePet.Species,
                BirthDate = updatePet.BirthDate
            };
        }

        public PetDTO? Delete(int id)
        {
            var pet = _petRepository.GetById(id);

            if(pet == null) return null;

            return new PetDTO
            {
                Id = pet.Id,
                ClientId = pet.ClientId,
                Name = pet.Name,
                Race = pet.Race,
                Gender = pet.Gender,
                Species = pet.Species,
                BirthDate = pet.BirthDate
            };
        }
    }
}
