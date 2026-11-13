using Application.Interfaces;
using Application.Models.Rating;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RatingDTO>>> Get()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RatingDTO>> GetById([FromRoute] int id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null) 
                return NotFound($"El rating con el Id: {id} no pudo ser encontrado");

            return Ok(rating);
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<List<RatingDTO>>> GetByClientIdAsync(int clientId)
        {
            var ratings = await _ratingService.GetByClientIdAsync(clientId);
            return Ok(ratings);
        }

        [HttpGet("shift/{shiftId}")]
        public async Task<ActionResult<List<RatingDTO>>> GetByShiftIdAsync(int shiftId)
        {
            var ratings = await _ratingService.GetByShiftIdAsync(shiftId);
            return Ok(ratings);
        }

        [HttpPost]
        public async Task<ActionResult<RatingDTO>> Add([FromBody] CreateRatingDTO rating)
        {
            var createdRating = await _ratingService.AddAsync(rating);
            if (createdRating == null) 
                return BadRequest($"El rating del turno: {rating.ShiftId} no pudo ser creado");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {id = createdRating.Id},
                value: createdRating
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RatingDTO>> Update([FromBody] RatingDTO rating, [FromRoute] int id)
        {
            if (rating == null) 
                return BadRequest("Los datos del rating están incompletos");
            if (rating.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el del rating");

            var updatedRating = await _ratingService.UpdateAsync(rating);
            if (updatedRating == null) 
                return NotFound($"El rating con el Id: {rating.Id} no pudo ser actualizado");

            return Ok(updatedRating);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RatingDTO>> Delete([FromRoute] int id)
        {
            var rating = await _ratingService.DeleteAsync(id);
            if (rating == null) 
                return NotFound($"El rating con el Id:{id} no pudo ser eliminado");

            return Ok(rating);
        }
    }
}