using Application.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        public List<OrderDTO> GetAll();
        public OrderDTO? GetById(int id);
        public OrderDTO? Add(CreateOrderDTO order);
        public OrderDTO? Update(OrderDTO order);
        public OrderDTO? Delete(int id);
    }
}