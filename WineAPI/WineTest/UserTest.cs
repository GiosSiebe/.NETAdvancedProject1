using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var user = new User();

            // Act & Assert
            Assert.AreEqual(0, user.UserId); // Default value for int is 0
            Assert.IsNull(user.UserName); // Default value for string is null
            Assert.IsNull(user.Password); // Default value for string is null
            Assert.IsNull(user.Token); // Default value for nullable string is null
        }

        [TestMethod]
        public void User_ShouldAllowSettingUserId()
        {
            // Arrange
            var user = new User();
            var expectedUserId = 1;

            // Act
            user.UserId = expectedUserId;

            // Assert
            Assert.AreEqual(expectedUserId, user.UserId);
        }

        [TestMethod]
        public void User_ShouldAllowSettingUserName()
        {
            // Arrange
            var user = new User();
            var expectedUserName = "johndoe";

            // Act
            user.UserName = expectedUserName;

            // Assert
            Assert.AreEqual(expectedUserName, user.UserName);
        }

        [TestMethod]
        public void User_ShouldAllowSettingPassword()
        {
            // Arrange
            var user = new User();
            var expectedPassword = "SecurePassword123";

            // Act
            user.Password = expectedPassword;

            // Assert
            Assert.AreEqual(expectedPassword, user.Password);
        }

        [TestMethod]
        public void User_ShouldAllowSettingToken()
        {
            // Arrange
            var user = new User();
            var expectedToken = "abcdef123456";

            // Act
            user.Token = expectedToken;

            // Assert
            Assert.AreEqual(expectedToken, user.Token);
        }

        [TestMethod]
        public void User_ShouldAllowSettingNullToken()
        {
            // Arrange
            var user = new User();
            string? expectedToken = null;

            // Act
            user.Token = expectedToken;

            // Assert
            Assert.IsNull(user.Token);
        }
    }
}
