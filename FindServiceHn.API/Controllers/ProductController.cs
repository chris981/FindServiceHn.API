using FindServiceHn.Database.Models;
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

        [HttpPost("addProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var result = await productManager.CreateProduct(product);
            if(result != null)
            {
                return this.Ok(result);
            }
            return this.BadRequest();
        }
    }
}
