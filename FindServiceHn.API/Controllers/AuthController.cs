using FindServiceHn.Database.Models;
using FindServiceHN.Core.Authentication;
using FindServiceHN.Core.Models;
using FindServiceHN.Core.UserManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindServiceHn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager userManager;
        public AuthController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = userManager.Authenticate(model);
            return Ok(response);
        }

        [Authorize(Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userManager.GetAll();
            return Ok(users);
        }

        [HttpGet("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var user = userManager.GetById(id);
            return Ok(user);
        }
    }
}
