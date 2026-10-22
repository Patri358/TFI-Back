using Application.Interfaces;
using Application.Models;
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
                Dni = u.Dni,
                Name = u.Name,
                Email = u.Email,
                Telefone = u.Telefone,
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
                Dni = user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telefone = user.Telefone,
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
                Dni = user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telefone = user.Telefone,
                State = user.State,
                BirthDate = user.BirthDate
            };
        }
        
        public UserDTO? Add(CreateUserDTO user)
        {
            var newUser = new UserDTO
            {
                Id = 4,
                Dni = user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telefone = user.Telefone,
                State = user.State,
                BirthDate = user.BirthDate
            };

            return newUser;
        }

        public UserDTO? Update(UserDTO user)
        {
            var updateUser = _userRepository.GetById(user.Id);
            if (updateUser == null) return null;

            updateUser.Id = user.Id;
            updateUser.Dni = user.Dni;
            updateUser.Name = user.Name;
            updateUser.Email = user.Email;
            updateUser.Telefone = user.Telefone;
            updateUser.State = user.State;
            updateUser.BirthDate = user.BirthDate;

            return new UserDTO
            {
                Id= updateUser.Id,
                Dni= updateUser.Dni,
                Name = updateUser.Name,
                Email = updateUser.Email,
                Telefone = updateUser.Telefone,
                State= updateUser.State,
                BirthDate= updateUser.BirthDate
            };
        }

        public UserDTO? Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Dni = user.Dni,
                Name = user.Name,
                Email = user.Email,
                Telefone = user.Telefone,
                State = user.State,
                BirthDate = user.BirthDate
            };
        }

    }
}
