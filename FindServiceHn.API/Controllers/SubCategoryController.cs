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
        private readonly ISubCategoriesManager subcategoryManager;

        public SubCategoryController(ISubCategoriesManager subcategoryManager)
        {
            this.subcategoryManager = subcategoryManager;
        }

        [HttpGet("GetSubCategories")]
        public async Task<IActionResult> GetAsync()
        {
            var categoriesResult = await subcategoryManager.GetAllAsync();
            if(!categoriesResult.Any())
            {
                return NotFound();
            }

            return Ok(categoriesResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] SubCategoriesDTO subcategory)
        {
            if (subcategory != null)
            {
                var result = await this.subcategoryManager.CreateSubCategoriesAsync(subcategory);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] SubCategory subcategories)
        {
            var result = await this.subcategoryManager.UpdateSubCategoriesAsync(subcategories);
            if (result != null)
                return this.Accepted(subcategories);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.subcategoryManager.DeleteSubCategoriesAsync(id);
            return this.Ok(result);
        }
    }
}
