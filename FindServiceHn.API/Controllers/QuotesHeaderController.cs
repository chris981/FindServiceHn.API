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
        [AllowAnonymous]//-----
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] QuotesHeaderDTO quotesheader)
        {
            if(quotesheader != null)
            {
                var result = await this.quotesheaderManager.CreateQuotesHeaderAsync(quotesheader);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] QuotesHeader quotesheader)
        {
            var result = await this.quotesheaderManager.UpdateQuotesHeaderAsync(quotesheader);
            if(result != null)
                return this.Accepted(quotesheader);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.quotesheaderManager.DeleteQuotesHeaderAsync(id);
            return this.Ok(result);
        }
    }
}