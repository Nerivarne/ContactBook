using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class UserService : IUserService
    {
        public ResponseMessage CreateNewUser(UserRegisterDTO user)
        {
            throw new NotImplementedException();
        }

        public bool DoesUserEmailExist(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
