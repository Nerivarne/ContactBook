using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ContactBook.Database;
using ContactBook.Models;
using ContactBook.Services;
using Moq;
using Xunit;

namespace TestProject.UnitTests
{
    public class UserServiceUnitTest
    {
        //Creating fields
        private UserService _userService;
        private readonly Mock<IDbContext> _mockAppDbContext = new Mock<IDbContext>();

        //Testing Database Related stuff
        public UserServiceUnitTest()
        {
            _userService = (new Mock<UserService>(_mockAppDbContext.Object)).Object;
        }

        [Fact]
        public void GetUserReturnsUser()
        {
            //arrange
            var data = new List<User> { new User("test@test.cz", "test") { Id = Guid.Parse("d9c47e6b-de98-4135-86bb-996e03800390") } };
            Guid id = Guid.Parse("d9c47e6b-de98-4135-86bb-996e03800390");

            _mockAppDbContext.Setup(db => db.Users).Returns(MoqSetup.SetupMockSet(data.AsQueryable()).Object);

            var expected = JsonSerializer.Serialize(data[0]);
            var actual = JsonSerializer.Serialize(_userService.GetUserByEmail("test@test.cz"));

            Assert.Equal(expected, actual);
        }
    }
}