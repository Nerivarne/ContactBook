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

        public ResponseMessage CreateNewUser(UserRegisterDTO user)
        {
            User newUser = new User(user.Email, user.Password);
            database.Users.Add(newUser);
            database.SaveChanges();
            return new ResponseMessage()
            {
                Message = "User has been registered."
            };
        }

        public bool DoesUserEmailExist(string userEmail)
        {
            return database.Users.Where(u => u.Email == userEmail).Any();
        }
    }
}
