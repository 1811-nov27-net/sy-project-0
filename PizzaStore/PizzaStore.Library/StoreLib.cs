using System;

namespace PizzaStore.Library
{
    /// <summary>
    /// Pizza Store with a name and its functions
    ///     -Name
    ///     -stock of ingredients
    ///         (the reason why we have a stock of ingredients
    ///         is because we are simply just reducing the count
    ///         whenever an ingredient is used)
    /// </summary>
    public class StoreLib
    {
        // needs store name
        // needs a set stock of ingredients

        private string _name;
        private int _stock;

        public StoreLib(string name)
        {
            _name = name;
        }

        // returns a name when requested
        // sets a name, however throws an error if the string is empty
        public string Name
        {
            get { return _name; }
            set
            {
                // if the length of the store name is 0, or thus empty
                if (value.Length == 0)
                {
                    // display this error message to user
                    throw new ArgumentException("Cannot have an empty store name.", nameof(value));
                }
                else
                    _name = value;
            }
        }

        public int Stock
        {
            get { return _stock; }
            set
            {
                // if the number of stock is <= 0
                if (value <= 0)
                {
                    // display this error message to user
                    throw new ArgumentException("The stock for this store cannot be zero or negative!");
                }
                else
                    _stock = value;
            }
        }
    }
}
