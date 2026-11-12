using Application.Interfaces;
using Application.Models.ClinicalRecord;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class ClinicalRecordService : IClinicalRecordService
    {
        private readonly IClinicalRecordRepository _clinicalRecordRepository;
        public ClinicalRecordService(IClinicalRecordRepository clinicalRecordRepository)
        {
            _clinicalRecordRepository = clinicalRecordRepository;
        }

        public async Task<List<ClinicalRecordDTO>> GetAllAsync()
        {
            var clinicalRecords = await _clinicalRecordRepository.GetAllAsync();
            return clinicalRecords.Select(cr => new ClinicalRecordDTO
            {
                Id = cr.Id,
                VeterinaryId = cr.VeterinaryId,
                PetId = cr.PetId,
                ShiftId = cr.ShiftId,
                RecordType = cr.RecordType,
                Observation = cr.Observation,
                Treatment = cr.Treatment,
                RegisterDate = cr.RegisterDate,
                Diagnostic = cr.Diagnostic,
            }).ToList();
        }

        public async Task<ClinicalRecordDTO?> GetByIdAsync(int id)
        {
            var clinicalRecord = await _clinicalRecordRepository.GetByIdAsync(id);

            if (clinicalRecord == null) return null;

            return new ClinicalRecordDTO
            {
                Id = clinicalRecord.Id,
                VeterinaryId = clinicalRecord.VeterinaryId,
                PetId = clinicalRecord.PetId,
                ShiftId = clinicalRecord.ShiftId,
                RecordType = clinicalRecord.RecordType,
                Observation = clinicalRecord.Observation,
                Treatment = clinicalRecord.Treatment,
                RegisterDate = clinicalRecord.RegisterDate,
                Diagnostic = clinicalRecord.Diagnostic
            };
        }

        public async Task<List<ClinicalRecordDTO>> GetByPetIdAsync(int petId)
        {
            var clinicalRecords = await _clinicalRecordRepository.GetByPetIdAsync(petId);
            return clinicalRecords.Select(cr => new ClinicalRecordDTO
            {
                Id = cr.Id,
                VeterinaryId = cr.VeterinaryId,
                PetId = cr.PetId,
                ShiftId = cr.ShiftId,
                RecordType = cr.RecordType,
                Observation = cr.Observation,
                Treatment = cr.Treatment,
                RegisterDate = cr.RegisterDate,
                Diagnostic = cr.Diagnostic
            }).ToList();
        }

        public async Task<List<ClinicalRecordDTO>> GetByVeterinaryIdAsync(int veterinaryId)
        {
            var clinicalRecords = await _clinicalRecordRepository.GetByVeterinaryIdAsync(veterinaryId);
            return clinicalRecords.Select(cr => new ClinicalRecordDTO
            {
                Id = cr.Id,
                VeterinaryId = cr.VeterinaryId,
                PetId = cr.PetId,
                ShiftId = cr.ShiftId,
                RecordType = cr.RecordType,
                Observation = cr.Observation,
                Treatment = cr.Treatment,
                RegisterDate = cr.RegisterDate,
                Diagnostic = cr.Diagnostic
            }).ToList();
        }

        public async Task<ClinicalRecordDTO?> AddAsync(CreateClinicalRecordDTO clinicalRecord)
        {
            var newClinicalRecord = new ClinicalRecord
            {
                VeterinaryId = clinicalRecord.VeterinaryId,
                PetId = clinicalRecord.PetId,
                ShiftId = clinicalRecord.ShiftId,
                RecordType = clinicalRecord.RecordType,
                Observation = clinicalRecord.Observation,
                Treatment = clinicalRecord.Treatment,
                RegisterDate = DateTime.Now,
                Diagnostic = clinicalRecord.Diagnostic
            };

            var addedClinicalRecord = await _clinicalRecordRepository.AddAsync(newClinicalRecord);
            await _clinicalRecordRepository.SaveChangesAsync();

            if (addedClinicalRecord == null || addedClinicalRecord.Id == 0) 
                return null;

            return new ClinicalRecordDTO
            {
                Id = addedClinicalRecord.Id,
                VeterinaryId = addedClinicalRecord.VeterinaryId,
                PetId = addedClinicalRecord.PetId,
                ShiftId = addedClinicalRecord.ShiftId,
                RecordType = addedClinicalRecord.RecordType,
                Observation = addedClinicalRecord.Observation,
                Treatment = addedClinicalRecord.Treatment,
                RegisterDate = addedClinicalRecord.RegisterDate,
                Diagnostic = addedClinicalRecord.Diagnostic
            };
        }

        public async Task<ClinicalRecordDTO?> UpdateAsync(ClinicalRecordDTO clinicalRecord)
        {
            var updateClinicalRecord = await _clinicalRecordRepository.GetByIdAsync(clinicalRecord.Id);

            if (updateClinicalRecord == null) return null;

            updateClinicalRecord.VeterinaryId = clinicalRecord.VeterinaryId;
            updateClinicalRecord.PetId = clinicalRecord.PetId;
            updateClinicalRecord.ShiftId = clinicalRecord.ShiftId;
            updateClinicalRecord.RecordType = clinicalRecord.RecordType;
            updateClinicalRecord.Observation = clinicalRecord.Observation;
            updateClinicalRecord.Treatment = clinicalRecord.Treatment;
            updateClinicalRecord.Diagnostic = clinicalRecord.Diagnostic;

            await _clinicalRecordRepository.UpdateAsync(updateClinicalRecord);
            await _clinicalRecordRepository.SaveChangesAsync();

            return new ClinicalRecordDTO
            {
                Id = updateClinicalRecord.Id,
                VeterinaryId = updateClinicalRecord.VeterinaryId,
                PetId = updateClinicalRecord.PetId,
                ShiftId = updateClinicalRecord.ShiftId,
                RecordType = updateClinicalRecord.RecordType,
                Observation = updateClinicalRecord.Observation,
                Treatment = updateClinicalRecord.Treatment,
                RegisterDate = updateClinicalRecord.RegisterDate,
                Diagnostic = updateClinicalRecord.Diagnostic,
            };
        }

        public async Task<ClinicalRecordDTO?> DeleteAsync(int id)
        {
            var clinicalRecord = await _clinicalRecordRepository.GetByIdAsync(id);
            if (clinicalRecord == null) return null;

            await _clinicalRecordRepository.DeleteAsync(id);
            await _clinicalRecordRepository.SaveChangesAsync();

            return new ClinicalRecordDTO
            {
                Id = clinicalRecord.Id,
                VeterinaryId = clinicalRecord.VeterinaryId,
                PetId = clinicalRecord.PetId,
                ShiftId = clinicalRecord.ShiftId,
                RecordType = clinicalRecord.RecordType,
                Observation = clinicalRecord.Observation,
                Treatment = clinicalRecord.Treatment,
                RegisterDate = clinicalRecord.RegisterDate,
                Diagnostic = clinicalRecord.Diagnostic,
            };
        }
    }
}