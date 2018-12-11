using PizzaStore.Library;
using System;
using Xunit;

namespace PizzaStore.Testing.Library
{
    /// <summary>
    ///     Testing logic for User, making sure tests pass where
    ///     it should pass and fail where it should fail
    /// </summary>
    
    public class UserTest
    {
        readonly User user = new User();

        [Theory]
        [InlineData("Jackie")]
        [InlineData("Bob")]
        [InlineData(" ")]
        public void UserWithFirstNameShouldSave(string firstname)
        {
            user.FirstName = firstname;
            Assert.Equal(firstname, user.FirstName);
        }

        [Theory]
        [InlineData("Chan")]
        [InlineData("Swagger")]
        [InlineData(" ")]
        public void UserWithLastNameShouldSave(string lastname)
        {
            user.LastName = lastname;
            Assert.Equal(lastname, user.LastName);
        }

        [Fact]
        public void UserWithNoFirstNameShouldReturnError()
        {
            Assert.ThrowsAny<ArgumentException>(() => user.FirstName = string.Empty);
        }

        [Fact]
        public void UserWithNoLastNameShouldReturnError()
        {
            Assert.ThrowsAny<ArgumentException>(() => user.LastName = string.Empty);
        }


    }
}
