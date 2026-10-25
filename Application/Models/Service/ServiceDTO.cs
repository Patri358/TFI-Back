using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Service
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}