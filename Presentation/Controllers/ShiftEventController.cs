using Application.Interfaces;
using Application.Models.ShiftEvent;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftEventController : ControllerBase
    {
        private readonly IShiftEventService _shiftEventService;
        public ShiftEventController(IShiftEventService shiftEventService)
        {
            _shiftEventService = shiftEventService;
        }

        [HttpGet("shift/{shiftId}")]
        public async Task<ActionResult<List<ShiftEventDTO>>> GetByShiftId([FromRoute] int shiftId)
        {
            var events = await _shiftEventService.GetByShiftIdAsync(shiftId);
            return Ok(events);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<ShiftEventDTO>>> GetByUserId([FromRoute] int userId)
        {
            var events = await _shiftEventService.GetByUserIdAsync(userId);
            return Ok(events);
        }
    }
}