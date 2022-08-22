using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.OrderStatusManager;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{

    [Route("api/[controller]")]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusManager orderStatusManager;
        public OrderStatusController(IOrderStatusManager orderStatusManager)
        {
            this.orderStatusManager = orderStatusManager;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return this.Ok(this.orderStatusManager.GetAll());
        }

        
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] OrderStatusDTO orderStatus)
        {
            if (orderStatus != null)
            {
                var result = await this.orderStatusManager.CreateOrderStatusAsync(orderStatus);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] OrderStatus orderStatus)
        {
            var result = await this.orderStatusManager.UpdateOrderStatusAsync(orderStatus);
            if (result != null)
                return this.Accepted(orderStatus);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.orderStatusManager.DeleteOrderStatusAsync(id);
            return this.Ok(result);
        }

    }
}