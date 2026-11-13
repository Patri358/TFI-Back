using Application.Interfaces;
using Application.Models.Order;
using Application.Models.OrderItem;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<List<OrderDTO>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(MapDTO).ToList();
        }

        public async Task<OrderDTO?> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return null;

            return MapDTO(order);
        }

        public async Task<OrderDTO?> AddAsync(CreateOrderDTO order)
        {
            if (order == null || order.Items == null) return null;

            // lista para no añadir en newOrder
            var orderItems = new List<OrderItem>();

            decimal total = 0;
            foreach (var item in order.Items)
            {
                var itemDB = await _itemRepository.GetByIdAsync(item.ItemId);
                if (itemDB == null)
                {
                    throw new Exception($"El Item con el id: {item.ItemId} no existe");
                }

                if(itemDB.Stock < item.Amount)
                {
                    throw new Exception($"El stock del Item {itemDB.Name} no es suficiente, Stock {itemDB.Stock}");
                }

                // resto la cantidad del pedido al producto y guardo el stock restante
                itemDB.Stock -= item.Amount;
                await _itemRepository.UpdateAsync(itemDB);

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
            await _itemRepository.SaveChangesAsync();

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

            var addedOrder = await _orderRepository.AddAsync(newOrder);
            await _orderRepository.SaveChangesAsync();
            if (addedOrder == null || addedOrder.Id == 0)
                return null;

            return MapDTO(addedOrder);
        }
 
        public async Task<OrderDTO?> UpdateAsync(OrderDTO order)
        {
            var updateOrder = await _orderRepository.GetByIdAsync(order.Id); 
            if(updateOrder == null) return null;
        
            updateOrder.ClientId = order.ClientId;
            updateOrder.DeliveryDate = order.DeliveryDate;
            updateOrder.PreparationDate = order.PreparationDate;
            updateOrder.PaymentMethod = order.PaymentMethod;
            updateOrder.Status = order.Status;
            updateOrder.Total = order.Total;
            updateOrder.Items = order.Items.Select(oi => new OrderItem
            {
                Id = oi.Id,
                OrderId = oi.OrderId,
                ItemId = oi.ItemId,
                Amount = oi.Amount,
                UnitPrice = oi.UnitPrice
            }).ToList();

            await _orderRepository.UpdateAsync(updateOrder);
            await _orderRepository.SaveChangesAsync();

            return MapDTO(updateOrder);
        }

        public async Task<OrderDTO?> DeleteAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null) return null;

            await _orderRepository.DeleteAsync(id);
            await _orderRepository.SaveChangesAsync();

            return MapDTO(order);
        }

        // metodo para mapear a dto la orden
        private static OrderDTO MapDTO(Order o)
        {
            return new OrderDTO
            {
                Id = o.Id,
                ClientId = o.ClientId,
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                PreparationDate = o.PreparationDate,
                PaymentMethod = o.PaymentMethod,
                Status = o.Status,
                Total = o.Total,
                Items = o.Items.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ItemId = oi.ItemId,
                    Amount = oi.Amount,
                    UnitPrice = oi.UnitPrice,
                }).ToList()
            };
        }
    }
}