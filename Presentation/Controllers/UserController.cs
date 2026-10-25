using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Interfaces;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Buscar todos
        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // Buscar por id
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById([FromRoute] int id)
        {
            var user = _userService.GetById(id);

            if(user == null) return NotFound("Usuario no encontrado");

            return Ok(user);
        }

        // Buscar por nombre
        [HttpGet("nombre/{name}")]
        public ActionResult<UserDTO> GetByName([FromRoute] string name)
        {
            var user = _userService.GetByName(name);

            if(user == null) return NotFound("Usuario no encontrado");

            return Ok(user);
        }

        // Crear usuario
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] CreateUserDTO user)
        {
            var usuarioCreado = _userService.Add(user);

            if (usuarioCreado == null) return NotFound();
            
            return CreatedAtAction(
                nameof(GetById),
                new {id = usuarioCreado.Id},
                usuarioCreado
                );
        }

        // Actualizar
        [HttpPut("{id}")]
        public ActionResult<UserDTO> Put([FromBody] UserDTO user, [FromRoute] int id)
        {
            if (user == null) return BadRequest("El usuario no puede estar vacío");

            user.Id = id;

            var usuarioActualizado = _userService.Update(user);

            if (usuarioActualizado == null) return NotFound(); 

            return Ok(usuarioActualizado);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var user = _userService.Delete(id);
            if(user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(user);
        }
    }
}
