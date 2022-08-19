using FindServiceHN.Core.ServicesStatusManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesStatusController : ControllerBase
    {
        private readonly IServicesStatusManager servicesStatusManager;

        public ServicesStatusController(IServicesStatusManager servicesStatusManager)
        {
            this.servicesStatusManager = servicesStatusManager;
        }

        [HttpGet("GetServicesStatus")]
        public async Task<IActionResult> GetAsync()
        {
            var servicesStatusResult = await this.servicesStatusManager.GetAllAsync();
            if (!servicesStatusResult.Any())
            {
                return NotFound();
            }

            return Ok(servicesStatusResult);
        }
    }
}
