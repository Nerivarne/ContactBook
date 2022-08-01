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

        [HttpGet("{contactId}")]
        [Authorize]
        public IActionResult Contact([FromRoute] int contactId)
        {
            var loggedInUser = tokenService.GetLoggedInUser();
            var contactDTO = contactService.ShowMeMyContact(contactId, loggedInUser, out bool isValid);
            //var contact = contactService.GetContactById(contactId);
            if (contactDTO != null)
                return Ok(contactDTO);
            return BadRequest();
        }

        [HttpPatch("")]
        [Authorize]
        public IActionResult EditContact([FromBody] EditContactDTO request)
        {
            var loggedInUser = tokenService.GetLoggedInUser();
            var editedContact = contactService.GetContactById(request.ContactId);
            var response = contactService.EditContact(request, editedContact, loggedInUser, out bool isEdited);
            if (isEdited)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("{contactId}")]
        [Authorize]
        public IActionResult DeleteContact([FromRoute] int contactId)
        {
            var loggedInUser = tokenService.GetLoggedInUser();
            var response = contactService.DeleteContact(contactId, loggedInUser, out bool isDeleted);
            if (isDeleted)
                return Ok(response);
            return BadRequest(response);
        }

    }
}
