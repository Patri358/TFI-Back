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
        public async Task<ActionResult<List<ItemDTO>>> Get()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetById([FromRoute] int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null) return NotFound($"No se encontró el Item con el Id: {id}");

            return Ok(item);
        }

        [HttpGet("(available)")]
        public async Task<ActionResult<List<ItemDTO>>> GetAvailableItems()
        {
            var availableItems = await _itemService.GetAvailableItemsAsync();
            return Ok(availableItems);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> AddAsync(CreateItemDTO item)
        {
            var createdItem = await _itemService.AddAsync(item);
            if (createdItem == null) 
                return BadRequest($"El item: {item.Name} no pudo ser creado");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { Id = createdItem.Id},
                value: createdItem
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDTO>> Update([FromBody] ItemDTO item, [FromRoute] int id)
        {
            if (item == null) 
                return BadRequest("Los datos del item están incompletos");
            if (item.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el del item");

            var updatedItem = await _itemService.UpdateAsync(item);
            if (updatedItem == null) 
                return NotFound($"No se encontró el Item con el Id: {id}");

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDTO>> DeleteAsync(int id)
        {
            var item = await _itemService.DeleteAsync(id);
            if (item == null) 
                return NotFound($"El Item con el Id:{id} no pudo ser eliminado");

            return Ok(item);
        }
    }
}