using FindServiceHN.Core.QuotesHeaderManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class Quotes_HeaderController : ControllerBase
    {
        private readonly IQuotesHeaderManager quotesheaderManager;

        public CategoryController(IQuotesHeaderManager quotesheaderManager)
        {
            this.quotesheaderManager = quotesheaderManager;
        }

        [HttpGet("GetQuotes")]
        public async Task<IActionResult> GetAsync()
        {
            var quotesheaderResult = await quotesheaderManager.GetAllAsync();
            if(!quotesheaderResult.Any())
            {
                return NotFound();
            }

            return Ok(quotesheaderResult);
        }
    }
}