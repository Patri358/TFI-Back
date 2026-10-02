using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
