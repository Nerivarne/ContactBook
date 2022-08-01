using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ContactBook.Interfaces;
using ContactBook.Models;
using Microsoft.IdentityModel.Tokens;

namespace ContactBook.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserService userService;
        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.userService = userService;
        }
        public string CreateLoginToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public User GetLoggedInUser()
        {
            var identity = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return userService.GetUserById(Guid.Parse(userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value));
            }
            return null;
        }
    }
}
