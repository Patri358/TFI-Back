using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using System.Runtime.CompilerServices;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order? GetById(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            return order;
        }

        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            return order;
        }

        public Order Update(Order order)
        {
            var index = _context.Orders.FindIndex(o => o.Id == order.Id);

            if (index == -1) return order;

            _context.Orders[index] = order;
            return order;
        }

        public Order? Delete(int id)
        {
            var order = GetById(id);
            if(order == null) return null;

            _context.Orders.Remove(order);
            return order;
        }

    }
}