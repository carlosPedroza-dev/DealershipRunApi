
using Microsoft.AspNetCore.Mvc;

namespace DealershipRun.AppHost.Order
{
    [ApiController]
    [Route("DealershipRun/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO dto) {
            var order = await _orderService.CreateOrder(dto.UserId, dto.CarId);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            var order = await _orderService.GetById(id);
            return Ok(order);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUser(long userId)
        {
            var orders = await _orderService.GetOrdersByUser(userId);
            return Ok(orders);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] OrderStatus status)
        {
            await _orderService.UpdateStatus(id, status);
            return NoContent();
        }

        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(long id)
        {
            await _orderService.CancelOrder(id);
            return NoContent();
        }
    }
}
