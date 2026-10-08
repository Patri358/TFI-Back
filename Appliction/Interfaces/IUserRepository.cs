using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetByName(string Name);
    }
}
