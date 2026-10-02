using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string OrderDate { get; set; } = string.Empty;
        public string DeliveryDate { get; set; } = string.Empty;
        public string PreparationDate { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
