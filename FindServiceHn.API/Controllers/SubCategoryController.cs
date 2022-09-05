using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.SubCategoriesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoriesManager subCategoryManager;

        public SubCategoryController(ISubCategoriesManager subCategoryManager)
        {
            this.subCategoryManager = subCategoryManager;
        }

        [HttpGet("GetSubCategories")]
        public async Task<IActionResult> GetAsync()
        {
            var subCategoriesResult = await subCategoryManager.GetAllAsync();
            if(!subCategoriesResult.Any())
            {
                return NotFound();
            }

            return Ok(subCategoriesResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] SubCategoriesDTO subCategory)
        {
            if (subCategory != null)
            {
                var result = await this.subCategoryManager.CreateSubCategoriesAsync(subCategory);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] SubCategory subCategory)
        {
            var result = await this.subCategoryManager.UpdateSubCategoriesAsync(subCategory);
            if (result != null)
                return this.Accepted(subCategory);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.subCategoryManager.DeleteSubCategoriesAsync(id);
            return this.Ok(result);
        }
    }
}
