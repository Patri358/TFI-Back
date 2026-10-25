using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Rating
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}