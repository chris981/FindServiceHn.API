using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.ProductManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }


        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetAsync()
        {
            var productResult = await productManager.GetAllAsync();
            if (!productResult.Any())
            {
                return NotFound();
            }

            return Ok(productResult);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] ProductDTO product)
        {
            if (product != null)
            {
                var result = await this.productManager.CreateProductAsync(product);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Product product)
        {
            var result = await this.productManager.UpdateProductAsync(product);
            if (result != null)
                return this.Accepted(product);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.productManager.DeleteProductAsync(id);
            return this.Ok(result);
        }
    }
}
