using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClinicalRecordRepository : IClinicalRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public ClinicalRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClinicalRecord>> GetAllAsync()
        {
            return await _context.ClinicalRecords.ToListAsync();
        }

        public async Task<ClinicalRecord?> GetByIdAsync(int id)
        {
            var clinicalRecord = await _context.ClinicalRecords.FirstOrDefaultAsync(cr => cr.Id == id);
            if (clinicalRecord == null) return null;

            return clinicalRecord;
        }

        public async Task<List<ClinicalRecord>> GetByPetIdAsync(int petId)
        {
            return await _context.ClinicalRecords
                .Where(cr => cr.PetId == petId)
                .ToListAsync();
        }
        public async Task<List<ClinicalRecord>> GetByVeterinaryIdAsync(int veterinaryId)
        {
            return await _context.ClinicalRecords
                .Where(cr => cr.VeterinaryId == veterinaryId)
                .ToListAsync();
        }

        public async Task<ClinicalRecord?> AddAsync(ClinicalRecord clinicalRecord)
        {
            await _context.ClinicalRecords.AddAsync(clinicalRecord);
            return clinicalRecord;
        }

        public async Task<ClinicalRecord?> UpdateAsync(ClinicalRecord clinicalRecord)
        {
            if (clinicalRecord == null) return null;

            _context.ClinicalRecords.Update(clinicalRecord);
            return clinicalRecord;
        }

        public async Task<ClinicalRecord?> DeleteAsync(int id)
        {
            var clinicalRecord = await GetByIdAsync(id);
            if (clinicalRecord == null) return null;

            _context.ClinicalRecords.Remove(clinicalRecord);
            return clinicalRecord;
        }
 
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}