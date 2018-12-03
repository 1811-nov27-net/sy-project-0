using System;

namespace PizzaStore.Library
{
    /// <summary>
    /// Pizza Store with a name and its functions
    ///     -inventory of ingredients
    ///     -ability to reject orders when ingredients are not available
    ///     -saved order history
    /// </summary>
    public class StoreDetails
    {
        // needs store name
        // needs a list of ingredients, and ability to save number of ingredients to disk
        // needs order history, saved to disk

        private string _storeName;

        public string StoreName
        {
            get { return _storeName; }
            set
            {
                // if the length of the store name is 0, or thus empty
                if (value.Length == 0)
                {
                    // display this error message to user
                    throw new ArgumentException("Cannot have an empty store name.", nameof(value));
                }
                else
                    _storeName = value;
            }
        }

        // need to decide which collection structure to use to store list of ingredients
        // Dictionary<type, type>, allows for pairing of ingredients to inventory number
        // Ingredients: pepperoni, olives, jalapenos, pineapple, bell peppers, mushrooms, chicken, sausage, spinach
        // (too much and it gets too complicated)
        // this way, we can throw an exception if the customer tries to request a pizza with an invalid ingredient


    }
}
