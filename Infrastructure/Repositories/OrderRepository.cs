using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using System.Runtime.CompilerServices;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<List<Order>> GetByClientIdAsync(int clientId)
        {
            var orders = await _context.Orders
                .Where(o => o.ClientId == clientId)
                .Include(o => o.Items)
                .ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetByStateAsync(OrderStatus status)
        {
            var orders = await _context.Orders
                .Where(o => o.Status == status)
                .Include(o => o.Items)
                .ToListAsync();
            return orders;
        }

        public async Task<Order?> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            return order;
        }

        public async Task<Order?> UpdateAsync(Order order)
        {
            if (order == null)
                return null;
            
            _context.Orders.Update(order);
            return order;
        }

        public async Task<Order?> DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);
            if(order == null) 
                return null;

            _context.Orders.Remove(order);
            return order;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        } 

    }
}