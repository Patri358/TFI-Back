using Application.Interfaces;
using Application.Models.Shift;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Application.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public List<ShiftDTO> GetAll()
        {
            var shifts = _shiftRepository.GetAll();
            return shifts.Select(s => new ShiftDTO
            {
                 Id = s.Id,
                 PetId = s.PetId,
                 VeterinaryId = s.VeterinaryId,
                 ClientId = s.ClientId,
                 ServiceId = s.ServiceId,
                 Status = s.Status,
                 ClientObs = s.ClientObs,
                 InitialDate = s.InitialDate,
                 EndDate = s.EndDate
            }).ToList();
        }

        public ShiftDTO? GetById(int id)
        {
            var shift  = _shiftRepository.GetById(id);

            if (shift == null) return null;

            return new ShiftDTO
            {
                Id = shift.Id,
                PetId = shift.PetId,
                VeterinaryId = shift.VeterinaryId,
                ClientId = shift.ClientId,
                ServiceId = shift.ServiceId,
                Status = shift.Status,
                ClientObs = shift.ClientObs,
                InitialDate = shift.InitialDate,
                EndDate = shift.EndDate
            };
        }

        public ShiftDTO? Add(CreateShiftDTO shift)
        {
            if (shift == null) return null;

            var newShift = new Shift
            {
                PetId = shift.PetId,
                VeterinaryId = shift.VeterinaryId,
                ClientId = shift.ClientId,
                ServiceId = shift.ServiceId,
                Status = ShiftStatus.Pendiente,
                ClientObs = shift.ClientObs,
                InitialDate = DateTime.Now,
                EndDate = null
            };

            var addedShift = _shiftRepository.Add(newShift);

            var newShiftDTO = new ShiftDTO
            {
                Id = addedShift.Id,
                PetId = addedShift.PetId,
                VeterinaryId = addedShift.VeterinaryId,
                ClientId = addedShift.ClientId,
                ServiceId = addedShift.ServiceId,
                Status = addedShift.Status,
                ClientObs = addedShift.ClientObs,
                InitialDate = addedShift.InitialDate,
                EndDate = addedShift.EndDate
            };

            return newShiftDTO;
        }

        public ShiftDTO? Update(ShiftDTO shift)
        {
            var updateShift = _shiftRepository.GetById(shift.Id);

            if (updateShift == null) return null;

            updateShift.PetId = shift.PetId;
            updateShift.VeterinaryId = shift.VeterinaryId;
            updateShift.ClientId = shift.ClientId;
            updateShift.ServiceId = shift.ServiceId;
            updateShift.Status = shift.Status;
            updateShift.ClientObs = shift.ClientObs;
            updateShift.InitialDate = shift.InitialDate;

            _shiftRepository.Update(updateShift);

            return new ShiftDTO
            {
                Id = updateShift.Id,
                PetId = updateShift.PetId,
                VeterinaryId = updateShift.VeterinaryId,
                ClientId = updateShift.ClientId,
                ServiceId = updateShift.ServiceId,
                Status = updateShift.Status,
                ClientObs = updateShift.ClientObs,
                InitialDate = updateShift.InitialDate,
                EndDate = updateShift.EndDate
            };
        }

        public ShiftDTO? Delete(int id)
        {
            var shift = _shiftRepository.GetById(id);

            if (shift == null) return null;

            _shiftRepository.Delete(shift.Id);

            return new ShiftDTO
            {
                Id = shift.Id,
                PetId = shift.PetId,
                VeterinaryId = shift.VeterinaryId,
                ClientId = shift.ClientId,
                ServiceId = shift.ServiceId,
                Status = shift.Status,
                ClientObs = shift.ClientObs,
                InitialDate = shift.InitialDate,
                EndDate = shift.EndDate
            };
        }
    }
}