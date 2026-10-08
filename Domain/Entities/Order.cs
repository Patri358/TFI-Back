using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime PreparationDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
