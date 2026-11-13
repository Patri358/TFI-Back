using Application.Models.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IServiceService
    {
        Task<List<ServiceDTO>> GetAllAsync();
        Task<ServiceDTO?> GetByIdAsync(int id);
        Task<List<ServiceDTO>> GetByTitleAsync(string title);
        Task<ServiceDTO?> AddAsync(CreateServiceDTO service);
        Task<ServiceDTO?> UpdateAsync(ServiceDTO service);
        Task<ServiceDTO?> DeleteAsync(int id);
    }
}