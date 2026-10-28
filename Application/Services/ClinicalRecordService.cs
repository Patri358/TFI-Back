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

        public List<ClinicalRecordDTO> GetAll()
        {
            var clinicalRecords = _clinicalRecordRepository.GetAll();

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

        public ClinicalRecordDTO? GetById(int id)
        {
            var clinicalRecord = _clinicalRecordRepository.GetById(id);

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

        public ClinicalRecordDTO? Add(CreateClinicalRecordDTO clinicalRecord)
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

            var addedClinicalRecord = _clinicalRecordRepository.Add(newClinicalRecord);

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

        public ClinicalRecordDTO? Update(ClinicalRecordDTO clinicalRecord)
        {
            var updateClinicalRecord = _clinicalRecordRepository.GetById(clinicalRecord.Id);

            if (updateClinicalRecord == null) return null;

            updateClinicalRecord.VeterinaryId = clinicalRecord.VeterinaryId;
            updateClinicalRecord.PetId = clinicalRecord.PetId;
            updateClinicalRecord.ShiftId = clinicalRecord.ShiftId;
            updateClinicalRecord.RecordType = clinicalRecord.RecordType;
            updateClinicalRecord.Observation = clinicalRecord.Observation;
            updateClinicalRecord.Treatment = clinicalRecord.Treatment;
            updateClinicalRecord.Diagnostic = clinicalRecord.Diagnostic;

            _clinicalRecordRepository.Update(updateClinicalRecord);

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

        public ClinicalRecordDTO? Delete(int id)
        {
            var clinicalRecord = _clinicalRecordRepository.GetById(id);

            if (clinicalRecord == null) return null;

            _clinicalRecordRepository.Delete(id);

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