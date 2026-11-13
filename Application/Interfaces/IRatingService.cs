using Application.Models.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IRatingService
    {
        public List<RatingDTO> GetAll();
        public RatingDTO? GetById(int id);
        public RatingDTO? Add(CreateRatingDTO rating);
        public RatingDTO? Update(RatingDTO rating);
        public RatingDTO? Delete(int id);
    }
}