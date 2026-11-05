using Infrastructure.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly ApplicationDbContext _context;
        public ShiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Shift> GetAll()
        {
            return _context.Shifts.ToList();
        }

        public Shift? GetById(int id)
        {
            var shift = _context.Shifts.FirstOrDefault(s => s.Id == id);
            if (shift == null) return null;

            return shift;
        }

        public Shift Add(Shift shift)
        {
            _context.Shifts.Add(shift);
            return shift;
        }

        public Shift Update(Shift shift)
        {
            _context.Shifts.Update(shift);
            return shift;
        }

        public Shift? Delete(int id)
        {
            var shift = GetById(id);
            if(shift == null) return null;

            _context.Shifts.Remove(shift);
            return shift;
        }
    }
}