using Microsoft.AspNetCore.Mvc;
using orderMicroService.Application.Services;
using orderMicroService.Domain.Entities;

namespace MicroServicesOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order, [FromHeader] int userId)
        {
            var created = await _orderService.Create(order, userId);
            if (!created)
            {
                return BadRequest("Could not create order");
            }
            return StatusCode(201, order);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Order order, [FromHeader] int userId)
        {
            var updated = await _orderService.Update(order, userId);
            if (!updated)
            {
                return NotFound("Order not found or could not be updated");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromHeader] int userId)
        {
            var deleted = await _orderService.DeleteById(id, userId);
            if (!deleted)
            {
                return NotFound("Order not found or could not be deleted");
            }
            return NoContent();
        }
    }
}
