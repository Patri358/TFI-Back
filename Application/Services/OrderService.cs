using Application.Interfaces;
using Application.Models.Order;
using Application.Models.OrderItem;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        public List<OrderDTO> GetAll()
        {
            var orders = _orderRepository.GetAll();
            return orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                ClientId = o.ClientId, 
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                PreparationDate = o.PreparationDate,
                PaymentMethod = o.PaymentMethod,
                Status = o.Status,
                Total = o.Total,
                Items = o.Items.Select(i => new OrderItemDTO
                {
                    Id = i.Id,
                    OrderId = i.OrderId,
                    ItemId = i.ItemId,
                    Amount = i.Amount,
                    UnitPrice = i.UnitPrice,
                }).ToList()
            }).ToList();
        }

        public OrderDTO? GetById(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null) return null;

            return new OrderDTO
            {
                Id = order.Id,
                ClientId = order.ClientId,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                PreparationDate = order.PreparationDate,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                Total = order.Total,
                Items = order.Items.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ItemId = oi.ItemId,
                    Amount = oi.Amount,
                    UnitPrice = oi.UnitPrice,
                }).ToList()
            };
        }

        public OrderDTO? Add(CreateOrderDTO order)
        {
            if (order == null || order.Items == null) return null;

            // lista para no añadir en newOrder
            var orderItems = new List<OrderItem>();

            decimal total = 0;
            foreach (var item in order.Items)
            {
                var itemDB = _itemRepository.GetById(item.ItemId);
                if (itemDB == null)
                {
                    throw new Exception($"El Item con el id: {item.ItemId} no existe");
                }

                if(itemDB.Stock < item.Amount)
                {
                    throw new Exception($"El stock del Item {itemDB.Name} no es suficiente, Stock {itemDB.Stock}");
                }

                // multiplico el precio del item de la base de datos por la cantidad solicitada y lo acumulo en el total
                decimal subtotal = itemDB.Price * item.Amount;
                total += subtotal;

                orderItems.Add(new OrderItem
                {
                    ItemId = item.ItemId,
                    Amount = item.Amount,
                    UnitPrice = itemDB.Price // precio del Item en la base de datos
                });
            }

            var newOrder = new Order
            {
                ClientId = order.ClientId,
                OrderDate = DateTime.Now,
                DeliveryDate = order.DeliveryDate,
                PreparationDate = order.PreparationDate,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                Total = total,
                Items = orderItems
            };

            var addedOrder = _orderRepository.Add(newOrder);

            return new OrderDTO
            {
                Id = addedOrder.Id,
                ClientId = addedOrder.ClientId,
                OrderDate = addedOrder.OrderDate,
                DeliveryDate = addedOrder.DeliveryDate,
                PreparationDate = addedOrder.PreparationDate,
                PaymentMethod = addedOrder.PaymentMethod,
                Status = addedOrder.Status,
                Total = addedOrder.Total,
                Items = addedOrder.Items.Select(i => new OrderItemDTO
                {
                    Id = i.Id,
                    OrderId = i.OrderId,
                    ItemId = i.ItemId,
                    Amount = i.Amount,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };
        }
 
        public OrderDTO? Update(OrderDTO order)
        {
            var updateOrder = _orderRepository.GetById(order.Id);
            
            if(updateOrder == null) return null;
        
            updateOrder.Id = order.Id;
            updateOrder.ClientId = order.ClientId;
            updateOrder.DeliveryDate = order.DeliveryDate;
            updateOrder.PreparationDate = order.PreparationDate;
            updateOrder.PaymentMethod = order.PaymentMethod;
            updateOrder.Status = order.Status;
            updateOrder.Total = order.Total;
            updateOrder.Items = order.Items.Select(oi => new OrderItem
            {
                Id = oi.Id,
                OrderId = oi.Id,
                ItemId = oi.ItemId,
                Amount = oi.Amount,
                UnitPrice = oi.UnitPrice
            }).ToList();

            _orderRepository.Update(updateOrder);

            return new OrderDTO
            {
                Id = updateOrder.Id,
                ClientId = updateOrder.ClientId,
                OrderDate = updateOrder.OrderDate,
                DeliveryDate = updateOrder.DeliveryDate,
                PreparationDate = updateOrder.PreparationDate,
                PaymentMethod = updateOrder.PaymentMethod,
                Status = updateOrder.Status,
                Total = updateOrder.Total,
                Items = updateOrder.Items.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ItemId = oi.ItemId,
                    Amount= oi.Amount,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };
        }

        public OrderDTO? Delete(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null) return null;

            _orderRepository.Delete(id);

            return new OrderDTO
            {
                Id = order.Id,
                ClientId = order.ClientId,
                OrderDate = order.OrderDate,
                DeliveryDate = order.DeliveryDate,
                PreparationDate = order.PreparationDate,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                Total = order.Total,
                Items = order.Items.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ItemId = oi.ItemId,
                    Amount = oi.Amount,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };
        }
    }
}