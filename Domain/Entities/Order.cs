using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? DeliveryDate { get; set; } = null;
        public DateTime? PreparationDate { get; set; } = null;
        public string PaymentMethod { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.PendientePago;
        public decimal Total { get; set; }

        // 1:n
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
    public enum OrderStatus
    {
        PendientePago,
        Pagado,
        Entregado,
        Cancelado
    }
}