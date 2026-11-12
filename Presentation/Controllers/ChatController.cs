using Application.Interfaces;
using Application.Models.Chat;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChatDTO>>> Get()
        {
            var chats = await _chatService.GetAllAsync();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatDTO>> GetById([FromRoute] int id)
        {
            var chat = await _chatService.GetByIdAsync(id);
            if (chat == null) 
                return NotFound($"Chat con el id {id} no existe");
            
            return Ok(chat);
        }

        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<List<ChatDTO>>> GetByClientId([FromRoute] int clientId)
        {
            var chats = await _chatService.GetByClientIdAsync(clientId);
            return Ok(chats);
        }

        [HttpGet("recepcionist/{recepcionistId}")]
        public async Task<ActionResult<List<ChatDTO>>> GetByRecepcionistIdAsync([FromRoute] int recepcionistId)
        {
            var chats = await _chatService.GetByRecepcionistIdAsync(recepcionistId);
            return Ok(chats);
        }

        [HttpPost]
        public async Task<ActionResult<ChatDTO>> Add([FromBody] CreateChatDTO chat)
        {
            var createdChat = await _chatService.AddAsync(chat);
            if (createdChat == null) return 
                    BadRequest("No se pudo crear el chat");

            // codigo 201
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdChat.Id},
                value: createdChat
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ChatDTO>> Update([FromBody] ChatDTO chat, [FromRoute] int id)
        {
            if (chat == null) 
                return BadRequest("Los datos del chat están incompletos");
            if (chat.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el del chat");

            var updateChat = await _chatService.UpdateAsync(chat);
            if (updateChat == null) 
                return NotFound($"El chat con el Id:{id} no pudo ser actualizado");

            return Ok(updateChat);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ChatDTO>> Delete([FromRoute] int id)
        {
            var chat = await _chatService.DeleteAsync(id);
            if (chat == null)
                return NotFound("El chat no existe");

            return Ok(chat);
        }
    }
}