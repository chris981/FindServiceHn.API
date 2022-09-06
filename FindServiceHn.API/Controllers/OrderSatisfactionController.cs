using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.OrderSatisfactionManager;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{

    [Route("api/[controller]")]
    public class OrderSatisfactionController : ControllerBase
    {
        private readonly IOrderSatisfactionManager orderSatisfactionManager;
        public OrderSatisfactionController(IOrderSatisfactionManager orderSatisfactionManager)
        {
            this.orderSatisfactionManager = orderSatisfactionManager;
        }

        [HttpGet("GetOrderSatisfaction")]
        public async Task<IActionResult> GetAllAsync()
        {
            var OrderSatisfactionResult = await this.orderSatisfactionManager.GetAllAsync();
            if (!OrderSatisfactionResult.Any())
            {
                return NotFound();
            }
            return this.Ok(OrderSatisfactionResult);
        }

       
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] OrderSatisfactionDTO orderSatisfaction)
        {
            if (orderSatisfaction != null)
            {
                var result = await this.orderSatisfactionManager.CreateOrderSatisfactionAsync(orderSatisfaction);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] OrderSatisfaction orderSatisfaction)
        {
            var result = await this.orderSatisfactionManager.UpdateOrderSatisfactionAsync(orderSatisfaction);
            if (result != null)
                return this.Accepted(orderSatisfaction);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.orderSatisfactionManager.DeleteOrderSatisfactionAsync(id);
            return this.Ok(result);
        }

    }
}