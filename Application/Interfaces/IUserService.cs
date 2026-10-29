using Application.Models;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserservice
    {
        List<UserDTO> GetAll();
        UserDTO? GetById(int id);
        UserDTO? GetByName(string name);
        UserDTO? Add(CreateUserDTO createUser);
        UserDTO? Update(UserDTO updateUser);
        UserDTO? Delete(int id);
    }
}