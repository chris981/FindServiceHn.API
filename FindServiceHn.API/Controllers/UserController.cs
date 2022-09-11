using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.UserManager;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var userResult = await this.userManager.GetAllAsync();
            if (!userResult.Any())
            {
                return NotFound();
            }

            return Ok(userResult);
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] UserDTO user)
        {
            if(user != null)
            {
                var result = await this.userManager.CreateUserAsync(user);
                return this.Ok(result);
            }
            return this.BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] User user)
        {
            var result = await this.userManager.UpdateUserAsync(user);
            if(result != null)
                return this.Accepted(user);

            return this.BadRequest();
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var result = await this.userManager.DeleteUserAsync(id);
            return this.Ok(result);
        }

    }
}
