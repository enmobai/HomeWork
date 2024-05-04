using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.Models;

namespace Assignment9.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> GetOrders() => orderService.GetAllOrders();

        [HttpGet("{id}")]
        public IActionResult GetOrder(string id) => orderService.GetOrder(id) is null ? NotFound() : Ok(orderService.GetOrder(id));

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            try
            {
                order.OrderId = Guid.NewGuid().ToString();
                orderService.AddOrder(order);
                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(string id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            try
            {
                orderService.UpdateOrder(order);
                return NoContent();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(string id)
        {
            try
            {
                orderService.RemoveOrder(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
    }
}
