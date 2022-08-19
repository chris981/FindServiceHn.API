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

    }
}
