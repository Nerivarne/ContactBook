using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string userEmail);
        User GetUserById(Guid userId);
        ResponseMessage CreateNewUser(UserRegisterDTO user);
        bool DoesUserEmailExist(string userEmail);
    }
}
