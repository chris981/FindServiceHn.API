using FindServiceHN.Core.ProvidersAttentionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    public class ProvidersAttentionController : ControllerBase
    {
        
        private readonly IProvidersAttentionManager providersattentionManager;

        public ProvidersAttentionController(IProvidersAttentionManager providersattentionManager)
        {
            this.providersattentionManager = providersattentionManager;
        }

        [HttpGet("GetProvidersAtt")]
        public async Task<IActionResult> GetAsync()
        {
            var providerattResult = await providersattentionManager.GetAllAsync();
            if(!providerattResult.Any())
            {
                return NotFound();
            }

            return Ok(providerattResult);
        }

        //---
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] ProvidersAttentionDTO providersattention)
        {
            if(providersattention != null)
            {
                var result = await this.providersattentionManager.CreateProvidersAttentionAsync(providersattention);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProvidersAttention providersattention)
        {
            var result = await this.providersattentionManager.UpdateProvidersAttentionAsync(providersattention);
            if(result != null)
                return this.Accepted(providersattention);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.providersattentionManager.DeleteProvidersAttentionAsync(id);
            return this.Ok(result);
        }
    }
}