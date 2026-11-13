using Application.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllAsync();
        Task<OrderDTO?> GetByIdAsync(int id);
        Task<OrderDTO?> AddAsync(CreateOrderDTO order);
        Task<OrderDTO?> UpdateAsync(OrderDTO order);
        Task<OrderDTO?> DeleteAsync(int id);
    }
}