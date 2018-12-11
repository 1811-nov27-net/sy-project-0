using PizzaStore.Library;
using System;
using Xunit;

namespace PizzaStore.Testing.Library
{
    /// <summary>
    ///     Testing logic for Inventory, making sure tests pass
    ///     where it should pass, and fail where it should fail
    /// </summary>
    
    public class InventoryTest
    {
        readonly Inventory inventory = new Inventory();

        [Fact]
        public void IngredientWithNoNameShouldReturnError()
        {
            Assert.ThrowsAny<ArgumentException>(() => inventory.IngredientName = string.Empty);
        }

        [Fact]
        public void IngredientWithNameShouldSave()
        {
            string randomIngredientName = "Anchovies";
            inventory.IngredientName = randomIngredientName;
            Assert.Equal(randomIngredientName, inventory.IngredientName);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        public void PriceWithIncorrectValueShouldReturnError(int cost)
        {
            Assert.ThrowsAny<ArgumentException>(() => inventory.Price = cost);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(648)]
        [InlineData(0)]
        public void PriceWithCorrectValueShouldSave(int cost)
        {
            inventory.Price = cost;
            Assert.Equal(cost, inventory.Price);
        }
    }
}
