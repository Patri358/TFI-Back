using Application.Interfaces;
using Application.Models;
using Application.Models.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            return users.Select(u => new UserDTO
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

        public UserDTO? GetById(int id)
        {
            var user = _userRepository.GetById(id);
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

        public UserDTO? GetByName(string name)
        {
            var user = _userRepository.GetByName(name);
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
        
        public UserDTO? Add(CreateUserDTO user)
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

            var addedUser = _userRepository.Add(newUser);

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

        public UserDTO? Update(UserDTO user)
        {
            var updateUser = _userRepository.GetById(user.Id);
            if (updateUser == null) return null;

            updateUser.Id = user.Id;
            updateUser.Rol = user.Rol;
            updateUser.Dni = user.Dni;
            updateUser.Name = user.Name;
            updateUser.Email = user.Email;
            updateUser.Telephone = user.Telephone;
            updateUser.State = user.State;
            updateUser.BirthDate = user.BirthDate;
            
            _userRepository.Update(updateUser);

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

        public UserDTO? Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return null;

            _userRepository.Delete(id);

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
