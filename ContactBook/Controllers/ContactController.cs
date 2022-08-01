using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        [HttpPost("")]
        [Authorize]
        public IActionResult AddNewContact()
        {
            return Ok();
        }

        [HttpGet("")]
        [Authorize]
        public IActionResult ListContacts()
        {
            return Ok();
        }

        [HttpPatch("")]
        [Authorize]
        public IActionResult EditContact()
        {
            return Ok();
        }

        [HttpDelete("")]
        [Authorize]
        public IActionResult DeleteContact()
        {
            return Ok();
        }

    }
}
