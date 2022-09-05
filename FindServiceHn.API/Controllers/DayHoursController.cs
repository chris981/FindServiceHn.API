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
        private readonly IDayHoursManager dayHoursManager;

        public DayHourController(IDayHoursManager dayHoursManager)
        {
            this.dayHoursManager = dayHoursManager;
        }

        [HttpGet("GetDayHours")]
        public async Task<IActionResult> GetAsync()
        {
            var dayHoursResult = await dayHoursManager.GetAllAsync();
            if(!dayHoursResult.Any())
            {
                return NotFound();
            }

            return Ok(dayHoursResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] DayHoursDTO dayHours)
        {
            if (dayHours != null)
            {
                var result = await this.dayHoursManager.CreateDayHoursAsync(dayHours);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] DayHour dayHours)
        {
            var result = await this.dayHoursManager.UpdateDayHoursAsync(dayHours);
            if (result != null)
                return this.Accepted(dayHours);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.dayHoursManager.DeleteDayHoursAsync(id);
            return this.Ok(result);
        }
    }
}
