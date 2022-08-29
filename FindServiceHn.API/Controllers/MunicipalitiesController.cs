using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.MunicipalitiesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly IMunicipalitiesManager municipalitiesManager;

        public MunicipalitiesController(IMunicipalitiesManager municipalitiesManager)
        {
            this.municipalitiesManager = municipalitiesManager;
        }
        [HttpGet("GetMunicipalities")]
        public async Task<IActionResult> GetAsync()
        {
            var MunicipalitiesResult = await municipalitiesManager.GetAllAsync();
            if (!MunicipalitiesResult.Any())
            {
                return NotFound();
            }
            return Ok(MunicipalitiesResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] MunicipalitiesDTO municipalities)
        {
            if (municipalities != null)
            {
                var result = await this.municipalitiesManager.CreateMunicipalityAsync(municipalities);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Municipalities municipalities)
        {
            var result = await this.municipalitiesManager.UpdateMunicipalityAsync(municipalities);
            if (result != null)
                return this.Accepted(municipalities);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.municipalitiesManager.DeleteMunicipalityAsync(id);
            return this.Ok(result);
        }
    }
}
