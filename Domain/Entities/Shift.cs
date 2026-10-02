using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class Shift
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VeterinaryId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ClientObs { get; set; } = string.Empty;
        public string InitialDate { get; set; } = string.Empty;
        public string FinalDate { get; set; } = string.Empty;
    }
}
