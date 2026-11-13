using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rating>> GetAllAsync()
        {
            var ratings = await _context.Ratings.ToListAsync();
            return ratings;
        }

        public async Task<Rating?> GetByIdAsync(int id)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.Id == id);
            if (rating == null) 
                return null;

            return rating;
        }

        public async Task<List<Rating>> GetByClientIdAsync(int clientId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.ClientId == clientId)
                .ToListAsync();

            return ratings;
        }
        public async Task<List<Rating>> GetByShiftIdAsync(int shiftId)
        {
            var ratings = await _context.Ratings
                .Where(r => r.ShiftId == shiftId)
                .ToListAsync();

            return ratings;
        }

        public async Task<Rating?> AddAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            return rating;
        }

        public async Task<Rating?> UpdateAsync(Rating rating)
        {
            if (rating == null)
                return null;

            _context.Ratings.Update(rating);
            return rating;
        }

        public async Task<Rating?> DeleteAsync(int id)
        {
            var rating = await GetByIdAsync(id);
            if (rating == null) 
                return null;

            _context.Ratings.Remove(rating);
            return rating;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}