using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IServiceVeterinaryRepository : IRepository<ServiceVeterinary>
    {
        Task<IEnumerable<ServiceVeterinary>> GetByVeterinaryIdAsync(int veterinaryId);
        Task<IEnumerable<ServiceVeterinary>> GetByServiceIdAsync(int serviceId);
    }
}
