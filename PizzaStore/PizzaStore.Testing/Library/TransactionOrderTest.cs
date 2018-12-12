using PizzaStore.Library;
using System;
using Xunit;

namespace PizzaStore.Testing.Library
{
    /// <summary>
    ///     Testing logic for TransactionOrder
    /// </summary>

    public class TransactionOrderTest
    {
        readonly TransactionOrder transactionOrder = new TransactionOrder();

        [Fact]
        public void SizeWithWrongInputShouldReturnError()
        {
            Assert.ThrowsAny<ArgumentException>(() => transactionOrder.Size = "t");
        }

        [Theory]
        [InlineData("l")]
        [InlineData("S")]
        [InlineData("M")]
        [InlineData("m")]
        public void SizeWithCorrectInputShouldSave(string pizzaSize)
        {
            transactionOrder.Size = pizzaSize;
            Assert.Equal(pizzaSize, transactionOrder.Size);
        }

        // toppings test, we only need to test one since they are all the same
        // (although this is bad code practice)
        // in this case we're just testing the Topping1 function
        [Fact]
        public void InvalidToppingNameShouldReturnError()
        {
            Assert.ThrowsAny<ArgumentException>(() => transactionOrder.Topping1 = string.Empty);
        }

        [Theory]
        [InlineData("Spaghetti")]
        [InlineData(" ")]
        [InlineData("asdfjkl;")]
        [InlineData("123 4309cna;")]
        public void ValidToppingNameShouldSave(string toppingName)
        {
            transactionOrder.Topping2 = toppingName;
            Assert.Equal(toppingName, transactionOrder.Topping2);
        }

        [Theory]
        [InlineData(-0.5)]
        [InlineData(-500)]
        [InlineData(-0.000001)]
        public void InvalidCostShouldReturnError(double price)
        {
            Assert.ThrowsAny<ArgumentException>(() => transactionOrder.Cost = price);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.01)]
        [InlineData(829.0912)]
        public void ValidCostShouldSave(double price)
        {
            transactionOrder.Cost = price;
            Assert.Equal(price, transactionOrder.Cost);
        }
    }
}
