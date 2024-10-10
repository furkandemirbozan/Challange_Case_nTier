using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Core.DTOs;
using Shipping.Core.Models;
using ShippingBusiness.Interfaces;

namespace ShippingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderDtos = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                CarrierId = order.CarrierId,
                OrderDesi = order.OrderDesi,
                OrderDate = order.OrderDate,
                OrderCarrierCost = order.OrderCarrierCost
            }).ToList();
            return Ok(orderDtos);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<string>> AddOrder([FromBody] OrderDTO orderDto)
        {
            var order = new Order
            {
                CarrierId = orderDto.CarrierId,
                OrderDesi = orderDto.OrderDesi,
                OrderDate = DateTime.Now,
                OrderCarrierCost = 0 // Kargo ücreti hesaplanacak
            };

            var result = await _orderService.AddOrderAsync(order);
            return Ok(result);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            return Ok(result);
        }
    }
}
