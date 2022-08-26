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
<<<<<<< HEAD
        }

        
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] ServicesStatusDTO servicesstatus)
        {
            if(servicesstatus != null)
            {
                var result = await this.servicesStatusManager.CreateServicesStatusAsync(servicesstatus);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] ServicesStatus servicesstatus)
        {
            var result = await this.servicesStatusManager.UpdateServicesStatusAsync(servicesstatus);
            if(result != null)
                return this.Accepted(servicesstatus);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.servicesstatusManager.DeleteServicesStatusAsync(id);
            return this.Ok(result);

        }
    }
}
