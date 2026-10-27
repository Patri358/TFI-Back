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

        public List<RatingDTO> GetAll()
        {
            var ratings = _ratingRepository.GetAll();
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

        public RatingDTO? GetById(int id)
        {
            var rating = _ratingRepository.GetById(id);
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

        public RatingDTO? Add(CreateRatingDTO rating)
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

            var addedRating = _ratingRepository.Add(newRating);

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

        public RatingDTO? Update(RatingDTO rating)
        {
            var updateRating = _ratingRepository.GetById(rating.Id);

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

            _ratingRepository.Update(updateRating);

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

        public RatingDTO? Delete(int id)
        {
            var rating = _ratingRepository.GetById(id);

            if (rating == null) return null;

            _ratingRepository.Delete(id);

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
