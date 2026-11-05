using Application.Models;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task <List<UserDTO>> GetAllAsync();
        Task <UserDTO?> GetByIdAsync(int id);
        Task <UserDTO?> GetByNameAsync(string name);
        Task <UserDTO?> AddAsync(CreateUserDTO createUser);
        Task <UserDTO?> UpdateAsync(UserDTO updateUser);
        Task <UserDTO?> DeleteAsync(int id);
    }
}