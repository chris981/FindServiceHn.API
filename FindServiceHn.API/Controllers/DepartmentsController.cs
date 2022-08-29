using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.DepartmentsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsManager departmentsManager;

        public DepartmentsController(IDepartmentsManager departmentsManager)
        {
            this.departmentsManager = departmentsManager;
        }
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetAsync()
        {
            var DepartmentsResult = await departmentsManager.GetAllAsync();
            if (!DepartmentsResult.Any())
            {
                return NotFound();
            }
            return Ok(DepartmentsResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] DepartmentsDTO departments)
        {
            if (departments != null)
            {
                var result = await this.departmentsManager.CreateDepartmentAsync(departments);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Departments departments)
        {
            var result = await this.departmentsManager.UpdateDepartmentAsync(departments);
            if (result != null)
                return this.Accepted(departments);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.departmentsManager.DeleteDepartmentAsync(id);
            return this.Ok(result);
        }

    }
}
