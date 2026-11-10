using Application.Interfaces;
using Application.Models.Shift;
using Application.Models.ShiftEvent;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShiftDTO>>> Get()
        {
            var shifts = await _shiftService.GetAllAsync();
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftDTO>> GetById([FromRoute] int id)
        {
            var shift = await _shiftService.GetByIdAsync(id);
            if (shift == null) return NotFound($"No se encontró el turno con Id: {id}");

            return Ok(shift);
        }

        [HttpPost]
        public async Task<ActionResult<ShiftDTO>> Add([FromBody] CreateShiftWithEventDTO request)
        {
            var createdShift = await _shiftService.AddAsync(request.shift, request.shiftEvent);
            if (createdShift == null) return BadRequest("No se pudo crear el turno");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdShift.Id },
                value: createdShift
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ShiftDTO>> Update([FromRoute] int id, [FromBody] UpdateShiftWithEventDTO request)
        {
            if (request == null) return BadRequest("Los datos del turno están incompletos");
            if (request.shift.Id != id) return BadRequest("El Id de la ruta no coincide con el del turno");

            var updatedShift = await _shiftService.UpdateAsync(request.shift, request.shiftEvent);
            if (updatedShift == null) return NotFound($"No se pudo actualizar el turno con Id: {request.shift.Id}");

            return Ok(updatedShift);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ShiftDTO>> Delete([FromRoute] int id)
        {
            var shift = await _shiftService.DeleteAsync(id);
            if (shift == null) return NotFound($"El turno con el Id:{id} no pudo ser eliminado");

            return Ok(shift);
        }
    }
}