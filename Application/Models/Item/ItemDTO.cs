using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Item
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}