using FindServiceHN.Core.ProvidersAttentionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    public class Providers_AttentionController : ControllerBase
    {
        
        private readonly IProviders_AttentionManager providers_attentionManager;

        public CategoryController(IProviders_AttentionManager providers_attentionManager)
        {
            this.providers_attentionManager = providers_attentionManager;
        }

        [HttpGet("GetProvidersAtt")]
        public async Task<IActionResult> GetAsync()
        {
            var providerattResult = await providers_attentionManager.GetAllAsync();
            if(!providerattResult.Any())
            {
                return NotFound();
            }

            return Ok(providerattResult);
        }
    }
}