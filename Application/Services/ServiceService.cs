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

        public async Task<List<ServiceDTO>> GetAllAsync()
        {
            var services = await _serviceRepository.GetAllAsync();
            return services.Select(s => new ServiceDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Price = s.Price,
                Duration = s.Duration
            }).ToList();
        }

        public async Task<ServiceDTO?> GetByIdAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
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

        public async Task<List<ServiceDTO>> GetByTitleAsync(string title)
        {
            var services = await _serviceRepository.GetByTitleAsync(title);
            return services.Select(s => new ServiceDTO
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Price = s.Price,
                Duration = s.Duration
            }).ToList();
        }

        public async Task<ServiceDTO?> AddAsync(CreateServiceDTO service)
        {
            if (service == null) return null;

            var newService = new Service
            {
                Title = service.Title,
                Description = service.Description,
                Price = service.Price,
                Duration = service.Duration
            };

            var addedService = await _serviceRepository.AddAsync(newService);
            await _serviceRepository.SaveChangesAsync();
            if (addedService == null || addedService.Id == 0)
                return null;

            return new ServiceDTO
            {
                Id = addedService.Id,
                Title = addedService.Title,
                Description = addedService.Description,
                Price = addedService.Price,
                Duration = addedService.Duration
            };
        }

        public async Task<ServiceDTO?> UpdateAsync(ServiceDTO service)
        {
            var updateService = await _serviceRepository.GetByIdAsync(service.Id);
            if (updateService == null) return null;

            updateService.Title = service.Title;
            updateService.Description = service.Description;
            updateService.Price = service.Price;
            updateService.Duration = service.Duration;

            await _serviceRepository.UpdateAsync(updateService);
            await _serviceRepository.SaveChangesAsync();

            return new ServiceDTO
            {
                Id = updateService.Id,
                Title = updateService.Title,
                Description = updateService.Description,
                Price = updateService.Price,
                Duration = updateService.Duration    
            };
        }

        public async Task<ServiceDTO?> DeleteAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            if (service == null) return null;

            await _serviceRepository.DeleteAsync(id);
            await _serviceRepository.SaveChangesAsync();

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