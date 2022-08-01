using ContactBook.Interfaces;
using ContactBook.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly ITokenService tokenService;
        private readonly IContactService contactService;
        public ContactController(ITokenService tokenService, IContactService contactService)
        {
            this.tokenService = tokenService;
            this.contactService = contactService;
        }
        [HttpPost("")]
        [Authorize]
        public IActionResult AddNewContact([FromBody] NewContactDTO newContact)
        {
            var loggedInUser = tokenService.GetLoggedInUser();
            ResponseMessage response = contactService.CreateContact(newContact, loggedInUser, out bool isContactCreate);
               if (isContactCreate)
                return Ok(response);
            return BadRequest(response);
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
