using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Application.Models.Item
{
    public class CreateItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}