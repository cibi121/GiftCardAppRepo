using GiftCardOrdering.Domain;
using GiftCardOrdering.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftCardOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            try
            {
                _orderService.CreateOrder(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
