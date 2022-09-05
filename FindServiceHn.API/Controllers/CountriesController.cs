using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
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
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] CountriesDTO countries)
        {
            if (countries != null)
            {
                var result = await this.countriesManager.CreateCountryAsync(countries);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Countries countries)
        {
            var result = await this.countriesManager.UpdateCountryAsync(countries);
            if (result != null)
                return this.Accepted(countries);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.countriesManager.DeleteCountryAsync(id);
            return this.Ok(result);
        }
    }
}
