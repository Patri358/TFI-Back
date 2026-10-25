using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.OrderItem
{
    public class CreateOrderItemDTO
    {
        public int ItemId { get; set; }
        public int Amount { get; set; }
    }
}