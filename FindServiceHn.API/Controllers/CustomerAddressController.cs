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
    }
}
