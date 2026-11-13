using Application.Models.Rating;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IRatingService
    {
        Task<List<RatingDTO>> GetAllAsync();
        Task<RatingDTO?> GetByIdAsync(int id);
        Task<List<RatingDTO>> GetByClientIdAsync(int clientId);
        Task<List<RatingDTO>> GetByShiftIdAsync(int shiftId);
        Task<RatingDTO?> AddAsync(CreateRatingDTO rating);
        Task<RatingDTO?> UpdateAsync(RatingDTO rating);
        Task<RatingDTO?> DeleteAsync(int id);
    }
}