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
    }
}
