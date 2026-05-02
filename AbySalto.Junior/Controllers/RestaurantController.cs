using AbySalto.Junior.Models.DTOs;
using AbySalto.Junior.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Junior.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RestaurantController : Controller
    {
        private readonly IOrderService _orderService;

        public RestaurantController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDto>> Create(CreateOrderDto dto){
            var order = await _orderService.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponseDto>>> GetAll([FromQuery] bool sortByTotal = false) {
            var orders = await _orderService.GetOrdersAsync(sortByTotal);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDto>> GetById(int id) {
            var order = await _orderService.GetOrderByIdAsync(id);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<OrderResponseDto>> Update(int id, UpdateOrderStatusDto updateOrderStatusDto) {
            var order = await _orderService.UpdateOrderStatusAsync(id, updateOrderStatusDto);
            return order is null ? NotFound() : Ok(order);
        }
    }
}
