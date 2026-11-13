using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetByClientIdAsync(int clientId);
        Task<List<Order>> GetByStateAsync(OrderStatus status);
    }
}
