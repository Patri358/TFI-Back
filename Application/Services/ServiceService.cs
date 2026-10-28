using Application.Interfaces;
using Application.Models.Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public List<ServiceDTO> GetAll()
        {
            var services = _serviceRepository.GetAll();
            return services.Select(s => new ServiceDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Price = s.Price,
                Duration = s.Duration
            }).ToList();
        }

        public ServiceDTO? GetById(int id)
        {
            var service = _serviceRepository.GetById(id);

            if (service == null) return null;

            return new ServiceDTO
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration
            };
        }

        public ServiceDTO? Add(CreateServiceDTO service)
        {
            if (service == null) return null;

            var newService = new Service
            {
                Title = service.Title,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration
            };

            var addedService = _serviceRepository.Add(newService);

            return new ServiceDTO
            {
                Id = addedService.Id,
                Title = addedService.Title,
                Description = addedService.Description,
                Price = addedService.Price,
                Duration = addedService.Duration
            };
        }

        public ServiceDTO? Update(ServiceDTO service)
        {
            var updateService = _serviceRepository.GetById(service.Id);

            if (updateService == null) return null;

            updateService.Title = service.Title;
            updateService.Description = service.Description;
            updateService.Price = service.Price;
            updateService.Duration = service.Duration;

            _serviceRepository.Update(updateService);

            return new ServiceDTO
            {
                Id = updateService.Id,
                Title = updateService.Title,
                Description = updateService.Description,
                Price = updateService.Price,
                Duration = updateService.Duration    
            };
        }

        public ServiceDTO? Delete(int id)
        {
            var service = _serviceRepository.GetById(id);

            if (service == null) return null;

            _serviceRepository.Delete(id);

            return new ServiceDTO
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration
            };
        }
    }
}