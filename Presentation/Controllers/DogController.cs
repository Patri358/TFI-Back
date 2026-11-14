using Application.Interfaces;
using Application.Models;
using Application.Models.Dog;
using Microsoft.AspNetCore.Mvc;

/*
 
 Revisar si es necesario validar la existencia de la raza o subraza y como lo maneja la api externa
 
 */


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogController : ControllerBase
    {
        private readonly IDogServices _dogServices;

        public DogController(IDogServices dogServices)
        {
            _dogServices = dogServices;
        }

        [HttpGet("breeds")]
        public async Task<ActionResult<List<BreedDTO>>> GetBreedListAsync()
            => Ok(await _dogServices.GetBreedListAsync());

        [HttpGet("breeds/{breed}")]
        public async Task<ActionResult<List<SubBreedDTO>>> GetSubBreedListAsync(string breed)
            => Ok(await _dogServices.GetSubBreedListAsync(breed));
        

        [HttpGet("random")]
        public async Task<ActionResult<DogImageDTO>> GetRandomDogAsync()
            => Ok(await _dogServices.GetRandomDogAsync());

        [HttpGet("random/{cantidad:int}")]
        public async Task<ActionResult<List<DogImageDTO>>> GetMultipleRandomDogAsync(int cantidad)
        {
            if (cantidad < 1)
                return BadRequest("La cantidad debe ser mayor a 0.");

            return Ok(await _dogServices.GetMultipleRandomDogAsync(cantidad));
        }

        [HttpGet("all/{breed}")]
        public async Task<ActionResult<List<DogImageDTO>>> GetDogsByBreedAsync(string breed)
            => Ok(await _dogServices.GetDogsByBreedAsync(breed));

        [HttpGet("random/{breed}")]
        public async Task<ActionResult<DogImageDTO>> GetRandomDogByBreedAsync(string breed)
            => Ok(await _dogServices.GetRandomDogByBreedAsync(breed));

        [HttpGet("random/{breed}/{cantidad:int}")]
        public async Task<ActionResult<List<DogImageDTO>>> GetMultipleRandomDogByBreedAsync(string breed, int cantidad)
        { 
            if (cantidad < 1)
                return BadRequest("La cantidad debe ser mayor a 0.");

            return Ok(await _dogServices.GetMultipleRandomDogByBreedAsync(breed, cantidad));
        }

        [HttpGet("all/{breed}/{subBreed}")]
        public async Task<ActionResult<List<DogImageDTO>>> GetDogsBySubBreedAsync(string breed, string subBreed)
            => Ok(await _dogServices.GetDogsBySubBreedAsync(breed, subBreed));

        [HttpGet("random/{breed}/{subBreed}")]
        public async Task<ActionResult<List<DogImageDTO>>> GetRandomDogBySubBreedAsync(string breed, string subBreed)
            => Ok(await _dogServices.GetRandomDogBySubBreedAsync(breed, subBreed));

        [HttpGet("random/{breed}/{subBreed}/{cantidad:int}")]
        public async Task<ActionResult<List<DogImageDTO>>> GetMultipleRandomDogBySubBreedAsync(string breed, string subBreed, int cantidad)
        { 
            if (cantidad < 1)
                return BadRequest("La cantidad debe ser mayor a 0.");

            return Ok(await _dogServices.GetMultipleRandomDogBySubBreedAsync(breed, subBreed, cantidad));
        }
    }
}
