using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Service
{
    public class CreateServiceDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}