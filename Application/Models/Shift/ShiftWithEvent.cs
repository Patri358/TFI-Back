using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Application.Models;
using Application.Models.ShiftEvent;

namespace Application.Models.Shift
{
    public class CreateShiftWithEventDTO
    {
        public CreateShiftDTO shift { get; set; } = null!;
        public CreateShiftEventDTO shiftEvent { get; set; } = null!;
    }

    public class UpdateShiftWithEventDTO
    {
        public ShiftDTO shift { get; set; } = null!;
        public CreateShiftEventDTO shiftEvent { get; set; } = null!;
    }
}