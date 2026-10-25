using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ClinicalRecordRepository : IClinicalRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public ClinicalRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ClinicalRecord> GetAll()
        {
            return _context.ClinicalRecords;
        }

        public ClinicalRecord? GetById(int id)
        {
            var clinicalRecord = _context.ClinicalRecords.FirstOrDefault(cr => cr.Id == id);
            if (clinicalRecord == null) return null;

            return clinicalRecord;
        }

        public ClinicalRecord Add(ClinicalRecord clinicalRecord)
        {
            _context.ClinicalRecords.Add(clinicalRecord);
            return clinicalRecord;
        }

        public ClinicalRecord Update(ClinicalRecord clinicalRecord)
        {
            var index = _context.ClinicalRecords.FindIndex(cr => cr.Id == clinicalRecord.Id);
            if (index == -1) return clinicalRecord;

            _context.ClinicalRecords[index] = clinicalRecord;
            return clinicalRecord;
        }

        public ClinicalRecord? Delete(int id)
        {
            var clinicalRecord = GetById(id);
            if (clinicalRecord == null) return null;

            _context.ClinicalRecords.Remove(clinicalRecord);
            return clinicalRecord;
        }
    }
}
