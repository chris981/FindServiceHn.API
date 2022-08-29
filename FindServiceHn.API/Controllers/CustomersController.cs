using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.CustomersManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersManager customersManager;

        public CustomersController(ICustomersManager customersManager)
        {
            this.customersManager = customersManager;
        }
        [HttpGet("GetCustomers")]
        public async Task<IActionResult> getAsync()
        {
            var customerResult = await customersManager.getAllAsync();
            if (!customerResult.Any())
            {
                return NotFound();
            }

            return Ok(customerResult);
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] CustomersDTO customers )
        {
            if (customers != null)
            {
                var result = await this.customersManager.CreateCustomerAsync(customers);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Customers customer)
        {
            var result = await this.customersManager.UpdateCustomerAsync(customer);
            if (result != null)
                return this.Accepted(customer);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.customersManager.DeleteCustomerAsync(id);
            return this.Ok(result);
        }
    }
}
