using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class ServiceVeterinary
    {
        public int Id { get; set; }
        public int VeterinaryId { get; set; }
        public int ServiceId { get; set; }
    }
}
