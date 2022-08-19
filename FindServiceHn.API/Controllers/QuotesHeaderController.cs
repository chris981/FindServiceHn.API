using FindServiceHN.Core.Quotes_HeaderManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesHeaderController : ControllerBase
    {
        private readonly IQuotesHeaderManager quotesheaderManager;

        public QuotesHeaderController(IQuotesHeaderManager quotesheaderManager)
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