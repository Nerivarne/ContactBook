using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string userEmail);
        User GetUserById(Guid userId);
        ResponseMessage CreateNewUser(UserRegisterDTO user, out bool isUserCreated);
        bool DoesUserEmailExist(string userEmail);
    }
}
