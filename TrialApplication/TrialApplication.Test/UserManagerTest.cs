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
        [Fact]
        public void RegisterUser_WrongPassword_ReturnFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x=>x.Equals("password")).Returns(true) ;

            var userManager = new UserManager(userRepositoryMock.Object);

            // Act 
            var result = userManager.RegisterUser("user", "");
            // Assert
            Assert.False(result) ;
        }

        // Correct Password shall return true
        [Fact]
        public void Login_CorrectPassword_ReturnsTrue()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.UserExists("username")).Returns(true);
            userRepositoryMock.Setup(x => x.GetPassword("username")).Returns("password");

            var userManager = new UserManager(userRepositoryMock.Object) ;
            //Act

            var result = userManager.Login("username", "password");
            //Assert
            Assert.True(result) ;
        }

        // Empty username
        [Fact]
        public void Login_EmptyUsername_ReturnsFalse()
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userManager = new UserManager(userRepositoryMock.Object);
            //Act
            var result = userManager.Login("","password");
            //Assert
            Assert.False(result);
        }

        // Empty password
        [Fact]
        public void Login_EmptyPassword_ReturnsFalse()
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userManager = new UserManager(userRepositoryMock.Object);
            //Act
            var result = userManager.Login("username", "");
            //Assert
            Assert.False(result);
        }

        // User Does not exist
        [Fact]
        public void Login_NoUser_ReturnsFalse()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x=>x.UserExists("username")).Returns(false);
            var userManager = new UserManager(userRepositoryMock.Object);

            //Act
            var result = userManager.Login("username", "password");

            //Assert
            Assert.False(result) ;
        }

        // Incorrect Password
        [Fact]
        public void Login_IncorrectPassword_ReturnsFalse()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.UserExists("username")).Returns(true);
            userRepositoryMock.Setup(x => x.GetPassword("username")).Returns("correctPassword");
            var userManager = new UserManager (userRepositoryMock.Object);

            //Act
            var result = userManager.Login("username", "incorrectPassword");

            //Assert
            Assert.False(result);
        }

        // Test cases for DeRegistering the user

        // Empty Username
        [Fact]
        public void DeRegister_EmptyUsername_ReturnsFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.DeRegister("", "password");

            // Assert
            Assert.False(result);
        }

        // Empty Password
        [Fact]
        public void DeRegister_EmptyPassword_ReturnsFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.DeRegister("username", "");

            // Assert
            Assert.False(result);
        }
        // User Does not Exists
        [Fact]
        public void DeRegister_UserDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x=>x.UserExists("username")).Returns(false);
            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.DeRegister("username", "password");

            // Assert
            Assert.False(result);
        }

        // Correct Exist
        [Fact]
        public void DeRegister_UserExist_ReturnsTrue()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.UserExists("username")).Returns(true);
            userRepositoryMock.Setup(x => x.GetPassword("username")).Returns("correctPassword");
            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.DeRegister("username", "correctPassword");

            // Assert
            Assert.True(result);
            userRepositoryMock.Verify(x=>x.DeregisterUser("username"),Times.Once());
        }

        // Incorrect User Entry
        [Fact]
        public void DeRegister_IncorrectUser_ReturnsTrue()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.UserExists("username")).Returns(true);
            userRepositoryMock.Setup(x => x.GetPassword("username")).Returns("correctPassword");
            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.DeRegister("username", "incorrectPassword");

            // Assert
            Assert.False(result);
            userRepositoryMock.Verify(x => x.DeregisterUser("username"), Times.Never());
        }

        // TEST CASES FOR LOGOUT METHOD
        
        [Fact]
        public void Logout_ValidUsername_ReturnsTrue()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.UserExists("username")).Returns(true);

            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.Logout("username");

            // Assert
            Assert.True(result);
        }
        
        // Invalid User 
        [Fact]
        public void Logout_InvalidUsername_ReturnsFalse()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.UserExists("nonexistentuser")).Returns(false);

            var userManager = new UserManager(userRepositoryMock.Object);

            // Act
            var result = userManager.Logout("nonexistentuser");

            // Assert
            Assert.False(result);
        }
    }
}
