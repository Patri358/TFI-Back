using Application.Interfaces;
using Application.Models;
using Application.Models.Pet;
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
        public async Task<ActionResult<List<PetDTO>>> Get()
        {
            var pets = await _petService.GetAllAsync();
            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDTO>> GetById(int id)
        {
            var pet = await _petService.GetByIdAsync(id);
            if (pet == null) 
                return NotFound($"No se encontró la mascota con el Id: {id}");

            return Ok(pet);
        }

        [HttpPost]
        public async Task <ActionResult<PetDTO>> Add([FromBody] CreatePetDTO pet)
        {
            var createdPet = await _petService.AddAsync(pet);
            if (createdPet == null) 
                return BadRequest($"La mascota {pet.Name} no pudo ser creada");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdPet.Id },
                value: createdPet
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PetDTO>> Update([FromBody] PetDTO pet, [FromRoute] int id)
        {
            if (pet == null) 
                return BadRequest("Los datos de la mascota están incompletos");
            if (pet.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el de la mascota");

            var updatePet = await _petService.UpdateAsync(pet);
            if (updatePet == null) 
                return NotFound($"La mascota con el Id: {pet.Id} no pudo ser actualizada");

            return Ok(updatePet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PetDTO>> Delete([FromRoute] int id)
        {
            var pet = await _petService.DeleteAsync(id);
            if (pet == null) 
                return NotFound($"La mascota con el Id: {id} no pudo ser eliminada");

            return Ok(pet);
        }
    }
}
