using Application.Interfaces;
using Application.Models.Item;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<ItemDTO>> Get()
        {
            var items = _itemService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetById([FromRoute] int id)
        {
            var item = _itemService.GetById(id);
            if (item == null) return NotFound($"No se encontró el Item con el Id: {id}");

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ItemDTO> Add(CreateItemDTO item)
        {
            var createdItem = _itemService.Add(item);
            if (createdItem == null) return BadRequest($"El item: {item.Name} no pudo ser creado");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { Id = createdItem.Id},
                value: createdItem
            );
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDTO> Update([FromBody] ItemDTO item, [FromRoute] int id)
        {
            if (item == null) return BadRequest("Los datos del item están incompletos");
            if (item.Id != id) return BadRequest("El Id de la ruta no coincide con el del item");

            var updatedItem = _itemService.Update(item);
            if (updatedItem == null) return NotFound($"No se encontró el Item con el Id: {id}");

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemDTO> Delete(int id)
        {
            var item = _itemService.Delete(id);
            if (item == null) return NotFound($"El Item con el Id:{id} no pudo ser eliminado");

            return Ok(item);
        }
    }
}