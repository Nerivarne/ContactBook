using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface IUserService
    {
        ResponseMessage CreateNewUser(UserRegisterDTO user);
        bool DoesUserEmailExist(string userEmail);
    }
}
