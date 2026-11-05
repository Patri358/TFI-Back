using Application.Interfaces;
using Application.Models;
using Application.Models.User;
using Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task <List<UserDTO>> GetAllAsync()
        {
            var Users = await _userRepository.GetAllAsync();
            return Users.Select(u => new UserDTO
            {
                Id = u.Id,
                Rol = u.Rol,
                Dni = u.Dni,
                Name = u.Name,
                Email = u.Email,
                Telephone = u.Telephone,
                State = u.State,
                BirthDate = u.BirthDate
            }).ToList();
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Rol = user.Rol,
                Dni = user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telephone = user.Telephone,
                State = user.State,
                BirthDate = user.BirthDate
            };
        }

        public async Task<UserDTO?> GetByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Rol = user.Rol,
                Dni = user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telephone = user.Telephone,
                State = user.State,
                BirthDate = user.BirthDate
            };
        }
        
        public async Task<UserDTO?> AddAsync(CreateUserDTO user)
        {
            if (user == null) return null;

            var newUser = new User
            {
                Rol = user.Rol,
                Dni= user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telephone = user.Telephone,
                State = user.State,
                BirthDate = user.BirthDate
            };

            var addedUser = await _userRepository.AddAsync(newUser);

            if (addedUser == null) return null;

            var newUserDTO = new UserDTO
            {
                Id = addedUser.Id,
                Rol = addedUser.Rol,
                Dni = addedUser.Dni,
                Name = addedUser.Name,
                Email = addedUser.Email,
                Telephone = addedUser.Telephone,
                State = addedUser.State,
                BirthDate = addedUser.BirthDate
            };

            return newUserDTO;
        }

        public async Task<UserDTO?> UpdateAsync(UserDTO user)
        {
            var updateUser = await _userRepository.GetByIdAsync(user.Id);
            if (updateUser == null) return null;

            updateUser.Rol = user.Rol;
            updateUser.Dni = user.Dni;
            updateUser.Name = user.Name;
            updateUser.Email = user.Email;
            updateUser.Telephone = user.Telephone;
            updateUser.State = user.State;
            updateUser.BirthDate = user.BirthDate;
            
            await _userRepository.UpdateAsync(updateUser);

            return new UserDTO
            {
                Id = updateUser.Id,
                Rol = updateUser.Rol,
                Dni= updateUser.Dni,
                Name = updateUser.Name,
                Email = updateUser.Email,
                Telephone = updateUser.Telephone,
                State = updateUser.State,
                BirthDate = updateUser.BirthDate
            };
        }

        public async Task<UserDTO?> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            await _userRepository.DeleteAsync(id);

            return new UserDTO
            {
                Id = user.Id,
                Rol = user.Rol,
                Dni = user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telephone = user.Telephone,
                State = user.State,
                BirthDate = user.BirthDate
            };
        }
    }
}