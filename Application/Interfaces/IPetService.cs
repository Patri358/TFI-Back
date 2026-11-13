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
        List<PetDTO> GetAll();
        PetDTO? GetById(int id);
        PetDTO? GetByClientId(int clientId);
        PetDTO? Add(CreatePetDTO pet);
        PetDTO? Update(PetDTO pet);
        PetDTO? Delete(int id);
    }
}