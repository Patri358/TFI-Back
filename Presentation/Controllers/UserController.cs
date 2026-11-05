using Application.Interfaces;
using Application.Models;
using Application.Models.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Runtime.InteropServices.Marshalling;
using System.Xml.Linq;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly IUserservice _Userservice;
        public UserController(IUserservice Userservice)
        {
            _Userservice = Userservice;
        }

        // Buscar todos
        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            var Users = _Userservice.GetAll();
            return Ok(Users);
        }

        // Buscar por id
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById([FromRoute] int id)
        {
            var user = _Userservice.GetById(id);
            if(user == null) return NotFound($"No se encontró el usuario con el Id: {id}");

            return Ok(user);
        }

        // Buscar por nombre
        [HttpGet("nombre/{name}")]
        public ActionResult<UserDTO> GetByName([FromRoute] string name)
        {
            var user = _Userservice.GetByName(name);
            if(user == null) return NotFound($"No se encontró el usuario con el nombre: {name}");

            return Ok(user);
        }

        // Crear usuario
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] CreateUserDTO user)
        {
            var createdUser = _Userservice.Add(user);
            if (createdUser == null) return NotFound($"El usuario: {user.Name} no pudo ser creado");
            
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {id = createdUser.Id},
                value: createdUser
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public ActionResult<UserDTO> Put([FromBody] UserDTO user, [FromRoute] int id)
        {
            if (user == null) return BadRequest("Los datos del usuario están incompletos");
            if (user.Id != id ) return BadRequest("El Id de la ruta no coincide con el del usuario");

            var updateUser = _Userservice.Update(user);
            if (updateUser == null) return NotFound($"El usuario con el Id: {id} no pudo ser actualizado"); 

            return Ok(updateUser);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var user = _Userservice.Delete(id);
            if(user == null) return NotFound($"El usuario con el Id: {id} no pudo ser eliminado");

            return Ok(user);
        }
    }
}