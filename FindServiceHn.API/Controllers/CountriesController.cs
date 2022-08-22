using FindServiceHN.Core.CountriesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesManager countriesManager;

        public CountriesController(ICountriesManager countriesManager)
        {
            this.countriesManager = countriesManager;
        }
        [HttpGet("GetCountries")]
        public async Task<IActionResult> GetAsync()
        {
            var countriesResult = await countriesManager.GetAllAsync();
            if (!countriesResult.Any())
            {
                return NotFound();
            }
            return Ok(countriesResult);
        }
    }
}
