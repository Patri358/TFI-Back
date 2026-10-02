using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class ShiftEvent
    {
        public int Id { get; set; }
        public int UsertId { get; set; }
        public int ShiftId { get; set; }
        public int ReasonCancellationId { get; set; }
        public int ReasonConsultationId { get; set; }
        public int NewVeterinaryId { get; set; }
        public int OldVeterinaryId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }
}
