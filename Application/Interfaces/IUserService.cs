using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAll();

        UserDTO GetById(int id);

        UserDTO GetByName(string name);
    }
}