using ContactBook.Interfaces;
using ContactBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDTO request)
        {
            ResponseMessage response = userService.CreateNewUser(request, out bool isUserCreated);
            if (isUserCreated)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginDTO request)
        {
            var actualUser = userService.GetUserByEmail(request.Email);
            if (actualUser == null || !actualUser.PasswordCheck(request.Password))
            {
                return BadRequest("User not found or the password you entered is incorrect");
            }

            string token = tokenService.CreateLoginToken(actualUser);

            return Ok(token);
        }
    }
}
