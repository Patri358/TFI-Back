using Application.Interfaces;
using Application.Models.Session;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public ActionResult<List<SessionDTO>> Get()
        {
            var sessions = _sessionService.GetAll();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public ActionResult<SessionDTO> GetById([FromRoute] int id)
        {
            var session = _sessionService.GetById(id);
            if (session == null) return NotFound($"No se encontró la sesión con Id:{id}");

            return Ok(session);
        }

        [HttpPost]
        public ActionResult<SessionDTO> Add([FromBody] CreateSessionDTO session)
        {
            var createdSession = _sessionService.Add(session);
            if (createdSession == null) return BadRequest("No se pudo crear la sesión");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdSession.Id },
                value: createdSession
            );
        }

        [HttpPut("{id}")]
        public ActionResult<SessionDTO> Update([FromBody] SessionDTO session, [FromRoute] int id)
        {
            if (session == null) return BadRequest("Los datos de la sesión están incompletos");
            if (session.Id != id) return BadRequest("El Id de la ruta no coincide con el de la sesión");

            var updatedSession = _sessionService.Update(session);
            if (updatedSession == null) return NotFound($"La sesión con el Id:{id} no pudo ser actualizada");

            return Ok(updatedSession);
        }

        [HttpDelete("{id}")]
        public ActionResult<SessionDTO> Delete([FromRoute] int id)
        {
            var session = _sessionService.Delete(id);
            if (session == null) return NotFound($"No se pudo eliminar la sesión con Id:{id}");
            
            return Ok(session);
        }
    }
}