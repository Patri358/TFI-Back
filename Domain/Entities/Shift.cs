using Domain.Entities;
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
        public ShiftStatus Status { get; set; } = ShiftStatus.Pendiente;
        public string ClientObs { get; set; } = string.Empty;
        public DateTime InitialDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public enum ShiftStatus
    {
        Pendiente,
        Activo,
        Completado,
        Cancelado
    }
}