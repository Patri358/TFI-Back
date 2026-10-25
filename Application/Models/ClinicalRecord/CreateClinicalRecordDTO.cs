using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.ClinicalRecord
{
    public class CreateClinicalRecordDTO
    {
        public int VeterinaryId { get; set; }
        public int PetId { get; set; }
        public int ShiftId { get; set; }
        public string RecordType { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public string Diagnostic { get; set; } = string.Empty;
    }
}
