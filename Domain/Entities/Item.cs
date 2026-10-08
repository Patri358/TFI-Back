using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int stock { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
