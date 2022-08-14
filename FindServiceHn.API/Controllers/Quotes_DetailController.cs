using FindServiceHN.Core.Quotes_DetailManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Quotes_DetailController : ControllerBase
    {
        private readonly IQuotes_DetailManager quotes_detailManager;

        public Quotes_DetailController(IQuotes_DetailManager quotes_detailManager)
        {
            this.quotes_detailManager = quotes_detailManager;
        }

        [HttpGet("GetQuotesDetail")]
        public async Task<IActionResult> GetAsync()
        {
            var quotesResult = await Quotes_DetailManager.GetAllAsync();
            if (!quotesResult.Any())
            {
                return NotFound();
            }

            return Ok(quotesResult);
        }
    }
}
