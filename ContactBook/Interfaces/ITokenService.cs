using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface ITokenService
    {
        string CreateLoginToken(User user);
        User GetLoggedInUser();
    }
}
