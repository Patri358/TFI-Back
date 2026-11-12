using Application.Models.ClinicalRecord;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IClinicalRecordService
    {
        Task<List<ClinicalRecordDTO>> GetAllAsync();
        Task<ClinicalRecordDTO?> GetByIdAsync(int id);
        Task<List<ClinicalRecordDTO>> GetByPetIdAsync(int petId);
        Task<List<ClinicalRecordDTO>> GetByVeterinaryIdAsync(int veterinaryId);
        Task<ClinicalRecordDTO?> AddAsync(CreateClinicalRecordDTO clinicalRecord);
        Task<ClinicalRecordDTO?> UpdateAsync(ClinicalRecordDTO clinicalRecord);
        Task<ClinicalRecordDTO?> DeleteAsync(int id);
    }
}