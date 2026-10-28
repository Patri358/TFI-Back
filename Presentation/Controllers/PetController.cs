using Application.Interfaces;
using Application.Models;
using Application.Models.Pet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<List<PetDTO>> Get()
        {
            var pets = _petService.GetAll();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public ActionResult<PetDTO> GetById(int id)
        {
            var pet = _petService.GetById(id);
            if (pet == null) return NotFound($"No se encontró la mascota con el Id: {id}");

            return Ok(pet);
        }

        [HttpPost]
        public ActionResult<PetDTO> Add([FromBody] CreatePetDTO pet)
        {
            var createdPet = _petService.Add(pet);
            if (createdPet == null) return BadRequest($"La mascota {pet.Name} no pudo ser creada");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdPet.Id },
                value: createdPet
            );
        }

        [HttpPut("{id}")]
        public ActionResult<PetDTO> Update([FromBody] PetDTO pet, [FromRoute] int id)
        {
            if (pet == null) return BadRequest("Los datos de la mascota están incompletos");
            if (pet.Id != id) return BadRequest("El Id de la ruta no coincide con el de la mascota");

            var updatePet = _petService.Update(pet);
            if (updatePet == null) return BadRequest($"La mascota con el Id: {pet.Id} no pudo ser actualizada");

            return Ok(updatePet);
        }

        [HttpDelete("{id}")]
        public ActionResult<PetDTO> Delete([FromRoute] int id)
        {
            var pet = _petService.Delete(id);
            if (pet == null) return NotFound($"La mascota con el Id: {id} no pudo ser eliminada");

            return Ok(pet);
        }
    }
}
