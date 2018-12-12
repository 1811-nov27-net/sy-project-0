using PizzaStore.Library;
using System;
using Xunit;

namespace PizzaStore.Testing.Library
{
    /// <summary>
    ///     Testing logic for Transactions
    /// </summary>

    public class TransactionsTest
    {
        readonly Transactions transactions = new Transactions();

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        [InlineData(9)]
        public void PizzaIdWithInvalidInputShouldReturnError(int pizzaid)
        {
            Assert.ThrowsAny<ArgumentException>(() => transactions.PizzaId = pizzaid);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(17)]
        [InlineData(500)]
        public void PizzaIdWithValidInputShouldSave(int pizzaid)
        {
            transactions.PizzaId = pizzaid;
            Assert.Equal(pizzaid, transactions.PizzaId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-47)]
        public void UserIdWithInvalidInputShouldReturnError(int userid)
        {
            Assert.ThrowsAny<ArgumentException>(() => transactions.UserId = userid);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(4209)]
        public void UserWithValidInputShouldSave(int userid)
        {
            transactions.UserId = userid;
            Assert.Equal(userid, transactions.UserId);
        }

        [Fact]
        public void StoreNameWithEmptyInputShouldReturnError()
        {
            Assert.ThrowsAny<ArgumentException>(() => transactions.StoreName = string.Empty);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("a")]
        [InlineData("Dominos")]
        public void StoreNameWithValidInputShouldSave(string storename)
        {
            transactions.StoreName = storename;
            Assert.Equal(storename, transactions.StoreName);
        }
    }
}
