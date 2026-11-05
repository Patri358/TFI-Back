using Application.Interfaces;
using Application.Models.Rating;
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
        public ActionResult<List<RatingDTO>> Get()
        {
            var ratings = _ratingService.GetAll();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public ActionResult<RatingDTO> GetById([FromRoute] int id)
        {
            var rating = _ratingService.GetById(id);
            if (rating == null) return NotFound($"El rating con el Id: {id} no pudo ser encontrado");

            return Ok(rating);
        }

        [HttpPost]
        public ActionResult<RatingDTO> Add([FromBody] CreateRatingDTO rating)
        {
            var createdRating = _ratingService.Add(rating);
            if (createdRating == null) return BadRequest($"El rating del turno: {rating.ShiftId} no pudo ser creado");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {Id = createdRating.Id},
                value: createdRating
            );
        }

        [HttpPut("{id}")]
        public ActionResult<RatingDTO> Update([FromBody] RatingDTO rating, [FromRoute] int id)
        {
            if (rating == null) return BadRequest("Los datos del rating están incompletos");
            if (rating.Id != id) return BadRequest("El Id de la ruta no coincide con el del rating");

            var updatedRating = _ratingService.Update(rating);
            if (updatedRating == null) return NotFound($"El rating con el Id: {rating.Id} no pudo ser actualizado");

            return Ok(updatedRating);
        }

        [HttpDelete("{id}")]
        public ActionResult<RatingDTO> Delete([FromRoute] int id)
        {
            var rating = _ratingService.Delete(id);
            if (rating == null) return NotFound($"El rating con el Id:{id} no pudo ser eliminado");

            return Ok(rating);
        }
    }
}