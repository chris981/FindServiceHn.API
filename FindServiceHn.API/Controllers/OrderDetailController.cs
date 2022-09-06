using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.MunicipalitiesManager;
using FindServiceHN.Core.OrderDetailManager;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager orderDetailManager;
        public OrderDetailController(IOrderDetailManager orderDetailManager)
        {
            this.orderDetailManager = orderDetailManager;
        }

        [HttpGet("GetOrderDetail")]
        public async Task<IActionResult> GetAllAsync()
        {
            var orderDetailResult = await this.orderDetailManager.GetAllAsync();
            if (!orderDetailResult.Any())
            {
                return NotFound();
            }
            return Ok(orderDetailResult);
 
        }

        
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] OrderDetailDTO orderDetail)
        {
            if(orderDetail != null)
            {
                var result = await this.orderDetailManager.CreateOrderDetailAsync(orderDetail);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] OrderDetail orderDetail)
        {
            var result = await this.orderDetailManager.UpdateOrderDetailAsync(orderDetail);
            if(result != null)
                return this.Accepted(orderDetail);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.orderDetailManager.DeleteOrderDetailAsync(id);
            return this.Ok(result);
        }

    }
}
