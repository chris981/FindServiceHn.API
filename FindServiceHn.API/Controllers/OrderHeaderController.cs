using FindServiceHN.Core.OrderStatusManager;
using FindServiceHn.Database.Models;
using Microsoft.AspNetCore.Mvc;
using FindServiceHN.Core.OrderHeaderManager;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    public class OrderHeaderController : ControllerBase
    {
        private readonly IOrderHeaderManager orderHeaderManager;
        public OrderHeaderController(IOrderHeaderManager orderHeaderManager)
        {
            this.orderHeaderManager = orderHeaderManager;
        }

        [HttpGet("GetOrderHeader")]
        public async Task<IActionResult> GetAllAsync()
        {
            var OrderHeaderResult = await this.orderHeaderManager.GetAllAsync();
            if (OrderHeaderResult.Any())
            {
                return NotFound();
            }
            return this.Ok(OrderHeaderResult);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] OrderHeaderDTO orderHeader)
        {
            if (orderHeader != null)
            {
                var result = await this.orderHeaderManager.CreateOrderHeaderAsync(orderHeader);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] OrderHeader orderHeader)
        {
            var result = await this.orderHeaderManager.UpdateOrderHeaderAsync(orderHeader);
            if (result != null)
                return this.Accepted(orderHeader);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.orderHeaderManager.DeleteOrderHeaderAsync(id);
            return this.Ok(result);
        }
    }
}
