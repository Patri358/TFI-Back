using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Shift
{
    public class CreateShiftDTO
    {
        public int PetId { get; set; }
        public int VeterinaryId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public string ClientObs { get; set; } = string.Empty;
        public DateTime InitialDate { get; set; }
    }
}