using Application.Interfaces;
using Application.Models.Shift;
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
        public ActionResult<List<ShiftDTO>> Get()
        {
            var shifts = _shiftService.GetAll();
            return Ok(shifts);
        }

        [HttpGet("{id}")]
        public ActionResult<ShiftDTO> GetById([FromRoute] int id)
        {
            var shift = _shiftService.GetById(id);
            if (shift == null) return NotFound($"No se encontró el turno con Id: {id}");

            return Ok(shift);
        }

        [HttpPost]
        public ActionResult<ShiftDTO> Add([FromBody] CreateShiftDTO shift)
        {
            var createdShift = _shiftService.Add(shift);
            if (createdShift == null) return BadRequest("No se pudo crear el turno");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdShift.Id },
                value: createdShift
            );
        }

        [HttpPut("{id}")]
        public ActionResult<ShiftDTO> Update([FromBody] ShiftDTO shift, [FromRoute] int id)
        {
            if (shift == null) return BadRequest("Los datos del turno están incompletos");
            if (shift.Id != id) return BadRequest("El Id de la ruta no coincide con el del turno");

            var updatedShift = _shiftService.Update(shift);
            if (updatedShift == null) return NotFound($"No se pudo actualizar el turno con Id: {shift.Id}");

            return Ok(updatedShift);
        }

        [HttpDelete("{id}")]
        public ActionResult<ShiftDTO> Delete([FromRoute] int id)
        {
            var shift = _shiftService.Delete(id);
            if (shift == null) return NotFound($"El turno con el Id:{id} no pudo ser eliminado");

            return Ok(shift);
        }
    }
}