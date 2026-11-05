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
        public ActionResult<List<OrderDTO>> GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetById([FromRoute] int id)
        {
            var order = _orderService.GetById(id);
            if (order == null) return NotFound($"La orden con el Id:{id} no pudo ser encontrada");

            return Ok(order);
        }

        [HttpPost]
        public ActionResult<OrderDTO> Add(CreateOrderDTO order)
        {
            var createdOrder = _orderService.Add(order);
            if (createdOrder == null) return BadRequest($"La orden no pudo ser creada");

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { id = createdOrder.Id },
                value: createdOrder
            );
        }

        [HttpPut("{id}")]
        public ActionResult<OrderDTO> Update([FromBody] OrderDTO order, [FromRoute] int id)
        {
            if (order == null) return BadRequest("Los datos de la orden están incompletos");
            if (order.Id != id) return BadRequest("El Id de la ruta no coincide con el de la orden");

            var updateOrder = _orderService.Update(order);
            if (updateOrder == null) return NotFound($"No se encontró la orden con el Id: {order.Id}");

            return Ok(updateOrder);
        }

        [HttpDelete("{id}")]
        public ActionResult<OrderDTO> Delete([FromRoute] int id)
        {
            var order = _orderService.Delete(id);
            if (order == null) return NotFound($"La orden con el Id:{id} no pudo ser eliminada");

            return Ok(order);
        }
    }
}