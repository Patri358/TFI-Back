using Application.Interfaces;
using Application.Models.Rating;
using Domain.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<List<RatingDTO>> GetAllAsync()
        {
            var ratings = await _ratingRepository.GetAllAsync();
            return ratings.Select(r => new RatingDTO
            {
                Id = r.Id,
                ClientId = r.ClientId,
                ShiftId = r.ShiftId,
                Date = r.Date,
                Description = r.Description,
                Score = r.Score,
            }).ToList();
        }

        public async Task<RatingDTO?> GetByIdAsync(int id)
        {
            var rating = await _ratingRepository.GetByIdAsync(id);
            if (rating == null) return null;

            return new RatingDTO
            {
                Id = rating.Id,
                ClientId = rating.ClientId,
                ShiftId = rating.ShiftId,
                Date = rating.Date,
                Description = rating.Description,
                Score = rating.Score,
            };
        }

        public async Task<List<RatingDTO>> GetByClientIdAsync(int clientId)
        {
            var ratings = await _ratingRepository.GetByClientIdAsync(clientId);
            return ratings.Select(r => new RatingDTO
            {
                Id = r.Id,
                ClientId = r.ClientId,
                ShiftId = r.ShiftId,
                Date = r.Date,
                Description = r.Description,
                Score = r.Score
            }).ToList();
        }
        public async Task<List<RatingDTO>> GetByShiftIdAsync(int shiftId)
        {
            var ratings = await _ratingRepository.GetByShiftIdAsync(shiftId);
            return ratings.Select(r => new RatingDTO
            {
                Id = r.Id,
                ClientId = r.ClientId,
                ShiftId = r.ShiftId,
                Date = r.Date,
                Description = r.Description,
                Score = r.Score
            }).ToList();
        }

        public async Task<RatingDTO?> AddAsync(CreateRatingDTO rating)
        {
            if(rating.Score < 1 || rating.Score > 5)
            {
                throw new Exception("El puntaje debe estar entre 1 y 5");
            }

            var newRating = new Rating
            {
                ClientId = rating.ClientId,
                ShiftId = rating.ShiftId,
                Date = DateTime.Now,
                Description = rating.Description,
                Score = rating.Score,
            };

            var addedRating = await _ratingRepository.AddAsync(newRating);
            await _ratingRepository.SaveChangesAsync();
            if (addedRating == null || addedRating.Id == 0)
                return null;

            return new RatingDTO
            {
                Id = addedRating.Id,
                ClientId = addedRating.ClientId,
                ShiftId = addedRating.ShiftId,
                Date = addedRating.Date,
                Description = addedRating.Description,
                Score = addedRating.Score,
            };
        }

        public async Task<RatingDTO?> UpdateAsync(RatingDTO rating)
        {
            var updateRating = await _ratingRepository.GetByIdAsync(rating.Id);

            if (updateRating == null) return null;
            if(rating.Score < 1 || rating.Score > 5)
            {
                throw new Exception("El puntaje debe estar entre 1 y 5");
            }

            updateRating.Id = rating.Id;
            updateRating.ClientId = rating.ClientId;
            updateRating.ShiftId = rating.ShiftId;
            updateRating.Description = rating.Description;
            updateRating.Score = rating.Score;

            await _ratingRepository.UpdateAsync(updateRating);
            await _ratingRepository.SaveChangesAsync();

            return new RatingDTO
            {
                Id = updateRating.Id,
                ClientId = updateRating.ClientId,
                ShiftId = updateRating.ShiftId,
                Date = updateRating.Date,
                Description = updateRating.Description,
                Score = updateRating.Score,
            };
        }

        public async Task<RatingDTO?> DeleteAsync(int id)
        {
            var rating = await _ratingRepository.GetByIdAsync(id);
            if (rating == null) return null;

            await _ratingRepository.DeleteAsync(id);
            await _ratingRepository.SaveChangesAsync();

            return new RatingDTO
            {
                Id = rating.Id,
                ClientId = rating.ClientId,
                ShiftId = rating.ShiftId,
                Date = rating.Date,
                Description = rating.Description,
                Score = rating.Score
            };
        }
    }
}