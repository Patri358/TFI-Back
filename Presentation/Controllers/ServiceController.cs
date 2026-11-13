using Application.Interfaces;
using Application.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceDTO>>> Get()
        {
            var services = await _serviceService.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetById([FromRoute] int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null) 
                return NotFound($"No se encontró el servicio con Id:{id}");

            return Ok(service);
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult<List<ServiceDTO>>> GetByTitleAsync([FromRoute] string title)
        {
            var services = await _serviceService.GetByTitleAsync(title);
            return Ok(services);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> Add([FromBody] CreateServiceDTO service)
        {
            var createdService = await _serviceService.AddAsync(service);
            if (createdService == null) 
                return BadRequest("No se pudo crear el servicio");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {id= createdService.Id},
                value: createdService
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceDTO>> Update([FromBody] ServiceDTO service, [FromRoute] int id)
        {
            if (service == null) 
                return BadRequest("Los datos del servicio están incompletos");
            if (service.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el del servicio");

            var updatedService = await _serviceService.UpdateAsync(service);
            if (updatedService == null) 
                return NotFound($"No se pudo actualizar el servicio con Id:{service.Id}");

            return Ok(updatedService);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceDTO>> Delete([FromRoute] int id)
        {
            var service = await _serviceService.DeleteAsync(id);
            if (service == null) 
                return NotFound($"El servicio con Id:{id} no pudo ser eliminado");

            return Ok(service);
        }
    }
}