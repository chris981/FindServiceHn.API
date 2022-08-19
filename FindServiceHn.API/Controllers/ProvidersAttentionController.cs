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
    }
}