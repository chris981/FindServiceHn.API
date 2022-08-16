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

    }
}
