using ContactBook.Database;
using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class UserService : IUserService
    {
        private AppDbContext database;
        public UserService(AppDbContext database)
        {
            this.database = database;
        }

        public User GetUserByEmail(string userEmail)
        {
            var searchedUser = database.Users.SingleOrDefault(u => u.Email == userEmail);
            return searchedUser;
        }

        public User GetUserById(Guid userId)
        {
            var searchedUser = database.Users.SingleOrDefault(u => u.Id == userId);
            return searchedUser;
        }

        public ResponseMessage CreateNewUser(UserRegisterDTO user, out bool isUserCreate)
        {
            User newUser = new User(user.Email, user.Password);
            if (!DoesUserEmailExist(user.Email))
            {
                isUserCreate = true;
                database.Users.Add(newUser);
                database.SaveChanges();
                return new ResponseMessage()
                {
                    Message = "User has been registered"
                };
            }
            isUserCreate = false;
            return new ResponseMessage()
            {
                Message = "User already exists"
            };
        }

        public bool DoesUserEmailExist(string userEmail)
        {
            return database.Users.Where(u => u.Email == userEmail).Any();
        }
    }
}
