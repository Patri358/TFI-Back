using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.ClinicalRecord
{
    public class ClinicalRecordDTO
    {
        public int Id { get; set; }
        public int VeterinaryId { get; set; }
        public int PetId { get; set; }
        public int ShiftId { get; set; }
        public string RecordType { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public string Diagnostic { get; set; } = string.Empty;
    }
}