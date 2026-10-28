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
        public ActionResult<List<ChatDTO>> Get()
        {
            var chats = _chatService.GetAll();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public ActionResult<ChatDTO> GetById([FromRoute] int id)
        {
            var chat = _chatService.GetById(id);
            if (chat == null) return NotFound($"Chat con el id {id} no existe");
            
            return Ok(chat);
        }

        [HttpPost]
        public ActionResult<ChatDTO> Add([FromBody] CreateChatDTO chat)
        {
            var createdChat = _chatService.Add(chat);
            if (createdChat == null) return BadRequest("No se pudo crear el chat");

            // codigo 201
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdChat.Id},
                value: createdChat
            );
        }

        [HttpPut("{id}")]
        public ActionResult<ChatDTO> Update([FromBody] ChatDTO chat, [FromRoute] int id)
        {
            if (chat == null) return BadRequest("Los datos del chat están incompletos");
            if (chat.Id != id) return BadRequest("El Id de la ruta no coincide con el del chat");

            var updateChat = _chatService.Update(chat);
            if (updateChat == null) return NotFound($"El chat con el Id:{id} no pudo ser actualizado");

            return Ok(updateChat);
        }

        [HttpDelete("{id}")]
        public ActionResult<ChatDTO> Delete([FromRoute] int id)
        {
            var chat = _chatService.Delete(id);
            if (chat == null) return NotFound("El chat no existe");

            return Ok(chat);
        }
    }
}