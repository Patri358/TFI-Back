using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Models.ShiftEvent
{
    public class ShiftEventDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShiftId { get; set; }
        public int? ReasonCancellationId { get; set; }
        public int? ReasonConsultationId { get; set; }
        public int? NewVeterinaryId { get; set; }
        public int? OldVeterinaryId { get; set; }
        public TypeShiftEvent Type { get; set; }
        public DateTime Date { get; set; }
    }
}