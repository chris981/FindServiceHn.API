using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.DayHoursManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayHourController : ControllerBase
    {
        private readonly IDayHoursManager dayhoursManager;

        public DayHourController(IDayHoursManager dayhoursManager)
        {
            this.dayhoursManager = dayhoursManager;
        }

        [HttpGet("GetDayHours")]
        public async Task<IActionResult> GetAsync()
        {
            var dayhoursResult = await dayhoursManager.GetAllAsync();
            if(!dayhoursResult.Any())
            {
                return NotFound();
            }

            return Ok(dayhoursResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] DayHoursDTO dayhours)
        {
            if (dayhours != null)
            {
                var result = await this.dayhoursManager.CreateDayHoursAsync(dayhours);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] DayHour dayhours)
        {
            var result = await this.dayhoursManager.UpdateDayHoursAsync(dayhours);
            if (result != null)
                return this.Accepted(dayhours);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.dayhoursManager.DeleteDayHoursAsync(id);
            return this.Ok(result);
        }
    }
}
