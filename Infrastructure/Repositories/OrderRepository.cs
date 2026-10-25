using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return 
        }



    }
}
//public int Id { get; set; }
//public int ClientId { get; set; }
//public DateTime OrderDate { get; set; }
//public DateTime DeliveryDate { get; set; }
//public DateTime PreparationDate { get; set; }
//public string PaymentMethod { get; set; } = string.Empty;
//public string State { get; set; } = string.Empty;
//public decimal Total { get; set; }