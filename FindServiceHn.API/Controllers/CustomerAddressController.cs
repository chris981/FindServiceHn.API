using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.CustomerAddressManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressManager customerAddressManager;

        public CustomerAddressController(ICustomerAddressManager customerAddressManager)
        {
            this.customerAddressManager = customerAddressManager;   
        }
        [HttpGet("GetCustomerAddress")]
        public async Task<IActionResult> GetAsync()
        {
            var customerResult = await customerAddressManager.GetAllAsync();
            if (!customerResult.Any())
            {
                return NotFound();
            }
            return Ok(customerResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] CustomerAddressDTO customerAddress)
        {
            if (customerAddress != null)
            {
                var result = await this.customerAddressManager.CreateCustomerAddressAsync(customerAddress);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomerAddress customerAddress)
        {
            var result = await this.customerAddressManager.UpdateCustomerAddressAsync(customerAddress);
            if (result != null)
                return this.Accepted(customerAddress);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.customerAddressManager.DeleteCustomerAddressAsync(id);
            return this.Ok(result);
        }
    }
}
