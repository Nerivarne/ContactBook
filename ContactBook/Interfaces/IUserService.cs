using ContactBook.Models;

namespace ContactBook.Interfaces
{
    public interface IUserService
    {
        public User GetUserByEmail(string userEmail);
        User GetUserById(Guid userId);
        ResponseMessage CreateNewUser(UserRegisterDTO user, out bool isUserCreate);
        bool DoesUserEmailExist(string userEmail);
    }
}
