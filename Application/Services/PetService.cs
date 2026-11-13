using Application.Interfaces;
using Application.Models;
using Application.Models.Pet;
using Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;
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

        public async Task<List<PetDTO>> GetAllAsync()
        {
            var pets = await _petRepository.GetAllAsync();

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

        public async Task<PetDTO?> GetByIdAsync(int id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
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

        public async Task<List<PetDTO>> GetByClientIdAsync(int clientId)
        {
            var pets = await _petRepository.GetByClientIdAsync(clientId);
            return pets.Select(p => new PetDTO
            {
                Id = p.Id,
                ClientId = p.ClientId,
                Name = p.Name,
                Race = p.Race,
                Gender = p.Gender,
                Species = p.Species,
                BirthDate = p.BirthDate
            }).ToList();
        }

        public async Task<PetDTO?> AddAsync(CreatePetDTO pet)
        {
            var newPet = new Pet
            {
                ClientId = pet.ClientId,
                Name = pet.Name,
                Race = pet.Race,
                Gender = pet.Gender,
                Species = pet.Species,
                BirthDate = pet.BirthDate,
            };

            var addedPet = await _petRepository.AddAsync(newPet);
            await _petRepository.SaveChangesAsync();
            if (addedPet == null || addedPet.Id == 0)
                return null;

            return new PetDTO
            {
                Id = addedPet.Id,
                ClientId = addedPet.ClientId,
                Name = addedPet.Name,
                Race = addedPet.Race,
                Gender = addedPet.Gender,
                Species = addedPet.Species,
                BirthDate = addedPet.BirthDate,
            };
        }

        public async Task<PetDTO?> UpdateAsync(PetDTO pet)
        {
            var updatePet = await _petRepository.GetByIdAsync(pet.Id);
            if (updatePet == null) return null;

            updatePet.ClientId = pet.ClientId;
            updatePet.Name = pet.Name;
            updatePet.Race = pet.Race;
            updatePet.Gender = pet.Gender;
            updatePet.Species = pet.Species;
            updatePet.BirthDate = pet.BirthDate;

            await _petRepository.UpdateAsync(updatePet);
            await _petRepository.SaveChangesAsync();

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

        public async Task<PetDTO?> DeleteAsync(int id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
            if(pet == null) return null;

            await _petRepository.DeleteAsync(id);
            await _petRepository.SaveChangesAsync();

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