using Application.Interfaces;
using Application.Models;
using Application.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Buscar todos
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var Users = await _userService.GetAllAsync();
            return Ok(Users);
        }

        // Buscar por id
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById([FromRoute] int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if(user == null) return NotFound($"No se encontró el usuario con el Id: {id}");

            return Ok(user);
        }

        // Buscar por nombre
        [HttpGet("nombre/{name}")]
        public async Task<ActionResult<UserDTO>> GetByName([FromRoute] string name)
        {
            var user = await _userService.GetByNameAsync(name);
            if(user == null) return NotFound($"No se encontró el usuario con el nombre: {name}");

            return Ok(user);
        }

        // Crear usuario
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] CreateUserDTO user)
        {
            var createdUser = await _userService.AddAsync(user);
            if (createdUser == null) return BadRequest($"El usuario: {user.Name} no pudo ser creado");
            
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {id = createdUser.Id},
                value: createdUser
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put([FromBody] UserDTO user, [FromRoute] int id)
        {
            if (user == null) return BadRequest("Los datos del usuario están incompletos");
            if (user.Id != id ) return BadRequest("El Id de la ruta no coincide con el del usuario");

            var updateUser = await _userService.UpdateAsync(user);
            if (updateUser == null) return NotFound($"El usuario con el Id: {id} no pudo ser actualizado"); 

            return Ok(updateUser);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task <ActionResult<UserDTO>>  Delete([FromRoute] int id)
        {
            var user = await _userService.DeleteAsync(id);
            if(user == null) return NotFound($"El usuario con el Id: {id} no pudo ser eliminado");

            return Ok(user);
        }
    }
}