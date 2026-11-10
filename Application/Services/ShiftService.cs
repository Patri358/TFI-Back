using Application.Interfaces;
using Application.Models.Shift;
using Application.Models.ShiftEvent;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Text;

namespace Application.Services
{
    public class ShiftService : IShiftService, IShiftEventService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IShiftEventRepository _shiftEventRepository;
        public ShiftService(IShiftRepository shiftRepository, IShiftEventRepository shiftEventRepository)
        {
            _shiftRepository = shiftRepository;
            _shiftEventRepository = shiftEventRepository;
        }

        public async Task<List<ShiftDTO>> GetAllAsync()
        {
            var shifts = await _shiftRepository.GetAllAsync();
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

        public async Task<ShiftDTO?> GetByIdAsync(int id)
        {
            var shift = await _shiftRepository.GetByIdAsync(id);
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

        // se añade la auditoria por medio del add del turno
        public async Task <ShiftDTO?> AddAsync(CreateShiftDTO shift, CreateShiftEventDTO shiftEvent)
        {
            if (shift == null || shiftEvent == null) return null;

            var now = DateTime.Now;

            var newShift = new Shift
            {
                PetId = shift.PetId,
                VeterinaryId = shift.VeterinaryId,
                ClientId = shift.ClientId,
                ServiceId = shift.ServiceId,
                Status = ShiftStatus.Pendiente,
                ClientObs = shift.ClientObs,
                InitialDate = now,
                EndDate = null
            };

            var addedShift = await _shiftRepository.AddAsync(newShift);
            await _shiftRepository.SaveChangesAsync();

            if (addedShift == null) return null;

            var newShiftEvent = new ShiftEvent
            {
                UserId = shiftEvent.UserId,
                ShiftId = addedShift.Id,
                ReasonConsultationId = shiftEvent.ReasonConsultationId,
                ReasonCancellationId = shiftEvent.ReasonCancellationId,
                NewVeterinaryId = shiftEvent.NewVeterinaryId,
                OldVeterinaryId = shiftEvent.OldVeterinaryId,
                Type = TypeShiftEvent.Creacion,
                Date = now
            };

            var addedShiftEvent = await _shiftEventRepository.AddAsync(newShiftEvent);
            await _shiftEventRepository.SaveChangesAsync();
            if (addedShiftEvent == null) return null;

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

        // se añade la auditoria por medio de la actualización del turno
        public async Task<ShiftDTO?> UpdateAsync(ShiftDTO shift, CreateShiftEventDTO shiftEvent)
        {
            if (shift == null || shiftEvent == null) return null;

            var updateShift = await _shiftRepository.GetByIdAsync(shift.Id);
            if (updateShift == null) return null;

            updateShift.PetId = shift.PetId;
            updateShift.VeterinaryId = shift.VeterinaryId;
            updateShift.ClientId = shift.ClientId;
            updateShift.ServiceId = shift.ServiceId;
            updateShift.Status = shift.Status;
            updateShift.ClientObs = shift.ClientObs;
            updateShift.InitialDate = shift.InitialDate;

            await _shiftRepository.UpdateAsync(updateShift);
            await _shiftRepository.SaveChangesAsync();

            // se crea la auditoría pero es de tipo actualización, finalización o cancelación
            var updateShiftEvent = new ShiftEvent
            {
                UserId = shiftEvent.UserId,
                ShiftId = updateShift.Id,
                ReasonConsultationId = shiftEvent.ReasonConsultationId,
                ReasonCancellationId = shiftEvent.ReasonCancellationId,
                NewVeterinaryId = shiftEvent.NewVeterinaryId,
                OldVeterinaryId = shiftEvent.OldVeterinaryId,
                Type = shiftEvent.Type,
                Date = DateTime.Now
            };
            await _shiftEventRepository.AddAsync(updateShiftEvent);
            await _shiftEventRepository.SaveChangesAsync();

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

        public async Task<ShiftDTO?> DeleteAsync(int id)
        {
            var shift = await _shiftRepository.GetByIdAsync(id);
            if (shift == null) return null;

            await _shiftRepository.DeleteAsync(shift.Id);
            await _shiftRepository.SaveChangesAsync();
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

        //------------------------------------ ShiftEvent (Tabla de auditoría) ------------------------------------
        public async Task<List<ShiftEventDTO>> GetByShiftIdAsync(int shiftId)
        {
            var shiftsEvent = await _shiftEventRepository.GetByShiftIdAsync(shiftId);

            return shiftsEvent.Select(se => new ShiftEventDTO
            {
                Id = se.Id,
                UserId = se.UserId,
                ShiftId = se.ShiftId,
                ReasonCancellationId = se.ReasonCancellationId,
                ReasonConsultationId = se.ReasonConsultationId,
                NewVeterinaryId = se.NewVeterinaryId,
                OldVeterinaryId = se.OldVeterinaryId,
                Type = se.Type,
                Date = se.Date
            }).ToList();

        }

        public async Task<List<ShiftEventDTO>> GetByUserIdAsync(int userId)
        {
            var shiftsEvent = await _shiftEventRepository.GetByUserIdAsync(userId);

            return shiftsEvent.Select(se => new ShiftEventDTO
            {
                Id = se.Id,
                UserId = se.UserId,
                ShiftId = se.ShiftId,
                ReasonCancellationId = se.ReasonCancellationId,
                ReasonConsultationId = se.ReasonConsultationId,
                NewVeterinaryId = se.NewVeterinaryId,
                OldVeterinaryId = se.OldVeterinaryId,
                Type = se.Type,
                Date = se.Date
            }).ToList();
        }
    }
}