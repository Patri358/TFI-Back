using Application.Interfaces;
using Application.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetAllAsync()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetByIdAsync([FromRoute] int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null) 
                return NotFound($"La orden con el Id:{id} no pudo ser encontrada");

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Add(CreateOrderDTO order)
        {
            var createdOrder = await _orderService.AddAsync(order);
            if (createdOrder == null) 
                return BadRequest($"La orden no pudo ser creada");

            return CreatedAtAction(
                actionName: nameof(GetByIdAsync),
                routeValues: new { id = createdOrder.Id },
                value: createdOrder
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> Update([FromBody] OrderDTO order, [FromRoute] int id)
        {
            if (order == null) 
                return BadRequest("Los datos de la orden están incompletos");
            if (order.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el de la orden");

            var updateOrder = await _orderService.UpdateAsync(order);
            if (updateOrder == null) 
                return NotFound($"No se encontró la orden con el Id: {order.Id}");

            return Ok(updateOrder);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDTO>> Delete([FromRoute] int id)
        {
            var order = await _orderService.DeleteAsync(id);
            if (order == null) 
                return NotFound($"La orden con el Id:{id} no pudo ser eliminada");

            return Ok(order);
        }
    }
}