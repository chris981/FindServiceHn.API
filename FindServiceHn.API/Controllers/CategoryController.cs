using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.CategoryManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetAsync()
        {
            var categoriesResult = await categoryManager.GetAllAsync();
            if(!categoriesResult.Any())
            {
                return NotFound();
            }

            return Ok(categoriesResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] CategoryDTO category)
        {
            if (category != null)
            {
                var result = await this.categoryManager.CreateCategoryAsync(category);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Category category)
        {
            var result = await this.categoryManager.UpdateCategoryAsync(category);
            if (result != null)
                return this.Accepted(category);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.categoryManager.DeleteCategoryAsync(id);
            return this.Ok(result);
        }
    }
}
