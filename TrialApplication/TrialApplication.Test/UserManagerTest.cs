using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TrialApplication.Controllers;
using Xunit;

namespace TrialApplication.Test
{
    public class UserManagerTest
    {
        [Fact]
        public void RegisterUser_RegisterUser_ReturnsTrue() 
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x=>x.UserExists("newUser")).Returns(false);

            var userManager = new UserManager(userRepositoryMock.Object);

            //Act
            var result = userManager.RegisterUser("newUser", "password");

            //Assert

            Assert.True(result);
        }

        [Fact]
        public void RegisterUser_IncompleteUser_ReturnsFalse()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userManager = new UserManager(userRepositoryMock.Object);

            //Act
            var result = userManager.RegisterUser("", "password");
            //Assert

            Assert.False(result);
        }

        [Fact]

        public void RegisterUser_AlreadyRegisteredUser_ReturnFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x=>x.UserExists("existingUser")).Returns(true) ;

            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.RegisterUser("existingUser", "password");

            // Assert
            Assert.False(result) ;

        }

    }
}
