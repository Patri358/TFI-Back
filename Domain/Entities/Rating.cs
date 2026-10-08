using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int score { get; set; }
    }
}
