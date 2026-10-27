using Application.Models.OrderItem;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Order
{
    public class CreateOrderDTO
    {
        public int ClientId { get; set; }
        public DateTime? DeliveryDate { get; set; } = null;
        public DateTime? PreparationDate { get; set; } = null;
        public string PaymentMethod { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.PendientePago;
        public List<CreateOrderItemDTO> Items { get; set;} = new List<CreateOrderItemDTO>();
    }
}