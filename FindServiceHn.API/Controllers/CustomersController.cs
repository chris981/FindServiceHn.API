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
    }
}
