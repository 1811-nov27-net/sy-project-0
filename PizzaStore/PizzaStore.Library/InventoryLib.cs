using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    /// <summary>
    ///     -Inventory has an ingredient name along with a price
    ///     -Instead of a dictionary, we will use a List with Tuple<>
    ///      to access data in Inventory from TransactionOrder
    /// </summary>
    
    public class InventoryLib
    {
        private string _ingredientName;
        private decimal _price;

        public InventoryLib(string name, decimal price)
        {
            _ingredientName = name;
            _price = price;
        }

        // returns ingredient name
        // sets ingredient name, must not be empty
        public string IngredientName
        {
            get { return _ingredientName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must have a valid ingredient!", nameof(value));
                }
                else
                    _ingredientName = value;
            }
        }

        // returns ingredient cost
        // sets ingredient cost, must be a valid integer equal to 0 or above
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cost must be a valid number!");
                }
                else
                    _price = value;
            }
        }
    }
}
