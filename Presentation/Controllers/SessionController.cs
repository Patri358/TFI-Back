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
        public async Task<ActionResult<List<SessionDTO>>> Get()
        {
            var sessions = await _sessionService.GetAllAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDTO>> GetById([FromRoute] int id)
        {
            var session = await _sessionService.GetByIdAsync(id);
            if (session == null) 
                return NotFound($"No se encontró la sesión con Id:{id}");

            return Ok(session);
        }

        [HttpGet("token/{token}")]
        public async Task<ActionResult<SessionDTO?>> GetByTokenAsync(string token)
        {
            var session = await _sessionService.GetByTokenAsync(token);
            return Ok(session);
        }
        
        [HttpGet("user/{userId}/active")]
        public async Task<ActionResult<List<SessionDTO>>> GetActiveSessionsByUserIdAsync(int userId)
        {
            var sessions = await _sessionService.GetActiveSessionsByUserIdAsync(userId);
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<ActionResult<SessionDTO>> Add([FromBody] CreateSessionDTO session)
        {
            var createdSession = await _sessionService.AddAsync(session);
            if (createdSession == null) 
                return BadRequest("No se pudo crear la sesión");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdSession.Id },
                value: createdSession
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SessionDTO>> Update([FromBody] SessionDTO session, [FromRoute] int id)
        {
            if (session == null) 
                return BadRequest("Los datos de la sesión están incompletos");
            if (session.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el de la sesión");

            var updatedSession = await _sessionService.UpdateAsync(session);
            if (updatedSession == null) 
                return NotFound($"La sesión con el Id:{id} no pudo ser actualizada");

            return Ok(updatedSession);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SessionDTO>> Delete([FromRoute] int id)
        {
            var session = await _sessionService.DeleteAsync(id);
            if (session == null) 
                return NotFound($"No se pudo eliminar la sesión con Id:{id}");
            
            return Ok(session);
        }
    }
}