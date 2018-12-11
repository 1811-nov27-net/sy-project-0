using PizzaStore.Library;
using System;
using Xunit;

namespace PizzaStore.Testing.Library
{
    public class StoreTest
    {
        /// <summary>
        ///     Testing logic for Store, making sure it works and tests properly
        ///     pass and fail where they should
        /// </summary>

        readonly Store store = new Store();

        [Fact]
        public void StoreWithNameShouldSave()
        {
            string storeName = "Tony's Pizza";
            store.Name = storeName;
            Assert.Equal(storeName, store.Name);
        }

        [Fact]
        public void StoreWithNoNameShouldReturnError()
        {
            Assert.ThrowsAny<ArgumentException>(() => store.Name = string.Empty);
        }

        [Fact]
        public void StoreWithZeroInventoryShouldReturnError()
        {
            int inventory = 0;
            Assert.ThrowsAny<ArgumentException>(() => store.Stock = inventory);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(100)]
        public void StoreStockShouldSave(int inventory)
        {
            store.Stock = inventory;
            Assert.Equal(inventory, store.Stock);
        }
    }
}
