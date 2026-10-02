using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class Service
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
