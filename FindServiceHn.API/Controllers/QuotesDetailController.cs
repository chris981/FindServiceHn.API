using FindServiceHN.Core.QuotesDetailManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesDetailController : ControllerBase
    {
        private readonly IQuotesDetailManager quotesdetailManager;

        public QuotesDetailController(IQuotesDetailManager quotesdetailManager)
        {
            this.quotesdetailManager = quotesdetailManager;
        }

        [HttpGet("GetQuotesDetail")]
        public async Task<IActionResult> GetAsync()
        {
            var quotesResult = await this.quotesdetailManager.GetAllAsync();
            if (!quotesResult.Any())
            {
                return NotFound();
            }

            return Ok(quotesResult);
        }
    }
}
