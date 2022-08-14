using FindServiceHN.Core.ServicesStatusManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesStatusController : ControllerBase
    {
        private readonly IServicesStatusManager ServicesStatusManager;

        public ServicesStatusController(IServicesStatusManager servicesStatusManager)
        {
            this.ServicesStatusManager = servicesStatusManager;
        }

        [HttpGet("GetServicesStatus")]
        public async Task<IActionResult> GetAsync()
        {
            var ServicesStatusResult = await ServicesStatusManager.GetAllAsync();
            if (!categoriesResult.Any())
            {
                return NotFound();
            }

            return Ok(ServicesStatusResult);
        }
    }
}
