using Application.Models.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IServiceService
    {
        public List<ServiceDTO> GetAll();
        public ServiceDTO? GetById(int id);
        public ServiceDTO? Add(CreateServiceDTO service);
        public ServiceDTO? Update(ServiceDTO service);
        public ServiceDTO? Delete(int id);
    }
}