using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public AuthController()
        {

        }
        [HttpPost("register")]
        public async Task<ActionResult> Register()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login()
        {
            return Ok();
        }
    }
}
