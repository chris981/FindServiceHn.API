using FindServiceHN.Core.Quotes_HeaderManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class Quotes_HeaderController : ControllerBase
    {
        private readonly IQuotes_HeaderManager quotes_headerManager;

        public CategoryController(IQuotes_HeaderManager quotes_headerManager)
        {
            this.quotes_headerManager = quotes_headerManager;
        }

        [HttpGet("GetQuotes")]
        public async Task<IActionResult> GetAsync()
        {
            var quotes_headerResult = await quotes_headerManager.GetAllAsync();
            if(!quotes_headerResult.Any())
            {
                return NotFound();
            }

            return Ok(quotes_headerResult);
        }
    }
}