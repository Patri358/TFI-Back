using Application.Models;
using Application.Models.Pet;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPetService
    {
        Task<List<PetDTO>> GetAllAsync();
        Task<PetDTO?> GetByIdAsync(int id);
        Task<List<PetDTO>> GetByClientIdAsync(int clientId);
        Task<PetDTO?> AddAsync(CreatePetDTO pet);
        Task<PetDTO?> UpdateAsync(PetDTO pet);
        Task<PetDTO?> DeleteAsync(int id);
    }
}