using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class Rating
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ShiftId { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int score { get; set; }
    }
}
