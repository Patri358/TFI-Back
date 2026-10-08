using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Shift
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VeterinaryId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ClientObs { get; set; } = string.Empty;
        public DateTime InitialDate { get; set; }
        public string DateTime { get; set; }
    }
}
