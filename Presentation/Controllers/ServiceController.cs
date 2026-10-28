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
        public ActionResult <List<ServiceDTO>> Get()
        {
            var services = _serviceService.GetAll();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceDTO> GetById([FromRoute] int id)
        {
            var service = _serviceService.GetById(id);
            if (service == null) return NotFound($"No se encontró el servicio con Id:{id}");

            return Ok(service);
        }

        [HttpPost]
        public ActionResult<ServiceDTO> Add([FromBody] CreateServiceDTO service)
        {
            var createdService = _serviceService.Add(service);
            if (createdService == null) return BadRequest("No se pudo crear el servicio");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {id= createdService.Id},
                value: createdService
            );
        }

        [HttpPut("{id}")]
        public ActionResult<ServiceDTO> Update([FromBody] ServiceDTO service, [FromRoute] int id)
        {
            if (service == null) return BadRequest("Los datos del servicio están incompletos");
            if (service.Id != id) return BadRequest("El Id de la ruta no coincide con el del servicio");

            var updatedService = _serviceService.Update(service);
            if (updatedService == null) return BadRequest($"No se pudo actualizar el servicio con Id:{service.Id}");

            return Ok(updatedService);
        }

        [HttpDelete("{id}")]
        public ActionResult<ServiceDTO> Delete([FromRoute] int id)
        {
            var service = _serviceService.Delete(id);
            if (service == null) return BadRequest($"El servicio con Id:{id} no pudo ser eliminado");

            return Ok(service);
        }
    }
}