using Application.Models.ClinicalRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IClinicalRecordService
    {
        public List<ClinicalRecordDTO> GetAll();
        public ClinicalRecordDTO? GetById(int id);
        public ClinicalRecordDTO? Add(CreateClinicalRecordDTO clinicalRecord);
        public ClinicalRecordDTO? Update(ClinicalRecordDTO clinicalRecord);
        public ClinicalRecordDTO? Delete(int id);
    }
}