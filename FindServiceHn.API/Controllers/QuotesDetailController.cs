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
        //-----
        
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] QuotesDetailDTO quotesdetail)
        {
            if(quotesdetail != null)
            {
                var result = await this.quotesdetailManager.CreateQuotesDetailAsync(quotesdetail);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] QuotesDetail quotesdetail)
        {
            var result = await this.quotesdetailManager.UpdateQuotesDetailAsync(quotesdetail);
            if(result != null)
                return this.Accepted(quotesdetail);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.quotesdetailManager.DeleteQuotesDetailAsync(id);
            return this.Ok(result);
        }
    }
}
