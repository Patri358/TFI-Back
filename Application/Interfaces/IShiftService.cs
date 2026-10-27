using Application.Models.Shift;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IShiftService
    {
        public List<ShiftDTO> GetAll();
        public ShiftDTO? GetById(int id);
        public ShiftDTO? Add(CreateShiftDTO shift);
        public ShiftDTO? Update(ShiftDTO shift);
        public ShiftDTO? Delete(int id);
    }
}
