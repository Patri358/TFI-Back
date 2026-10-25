using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using MySqlConnector.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Rating> GetAll()
        {
            return _context.Ratings;
        }

        public Rating? GetById(int id)
        {
            var rating = _context.Ratings.FirstOrDefault(r => r.Id == id);
            if (rating == null) return null;

            return rating;
        }

        public Rating Add(Rating rating)
        {
            _context.Ratings.Add(rating);
            return rating;
        }

        public Rating Update(Rating rating)
        {
            var index = _context.Ratings.FindIndex(r => r.Id == rating.Id);
            if (index == -1) return rating;

            _context.Ratings[index] = rating;
            return rating;
        }

        public Rating? Delete(int id)
        {
            var rating = GetById(id);
            if (rating == null) return null;

            _context.Ratings.Remove(rating);
            return rating;
        }
    }
}
