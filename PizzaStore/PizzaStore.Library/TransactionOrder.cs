using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    /// <summary>
    ///     TransactionOrder is essentially the pizza itself;
    ///     consists of:
    ///         PizzaId, Size, Toppings 1-5, and a total Cost
    ///     Each PizzaId is unique, and ingredients should refer
    ///     to a dictionary object of Inventory
    ///     ALL pizza orders must be saved
    /// </summary>

    class TransactionOrder
    {
        // a dictionary that takes objects from the Inventory class as the key and value pair,
        // in this case being the IngredientName and Price
        // the "string" for item1 in dictionary will represent the key we want to look for, in this case IngredientName
        public Dictionary<string, Inventory> IngredientDetails { get; set; } = new Dictionary<string, Inventory>();

        public int PizzaId { get; set; }

        private char _size;
        private string _topping1;
        private string _topping2;
        private string _topping3;
        private string _topping4;
        private string _topping5;
        private double _cost;

        // returns pizza size
        // sets pizza size, must be a valid size choice
        public char Size
        {
            get { return _size; }
            set
            {
                // if the value does not equal these options
                if (value != 'S' || value != 's' || value != 'M' || value != 'm' || value != 'L' || value != 'l')
                {
                    throw new ArgumentException("Must be a valid size option!", nameof(value));
                }
                else
                    _size = value;
            }
        }

        public string Topping1
        {
            get { return _topping1; }
            set
            {
                // if the search key isn't in the dictionary
                if (!IngredientDetails.ContainsKey(value))
                {
                    throw new ArgumentException("This ingredient doesn't exist.", nameof(value));
                }
                else
                    _topping1 = value;
            }
        }

        public string Topping2
        {
            get { return _topping2; }
            set
            {
                // if the search key isn't in the dictionary
                if (!IngredientDetails.ContainsKey(value))
                {
                    throw new ArgumentException("This ingredient doesn't exist.", nameof(value));
                }
                else
                    _topping2 = value;
            }
        }

        public string Topping3
        {
            get { return _topping3; }
            set
            {
                // if the search key isn't in the dictionary
                if (!IngredientDetails.ContainsKey(value))
                {
                    throw new ArgumentException("This ingredient doesn't exist.", nameof(value));
                }
                else
                    _topping3 = value;
            }
        }

        public string Topping4
        {
            get { return _topping4; }
            set
            {
                // if the search key isn't in the dictionary
                if (!IngredientDetails.ContainsKey(value))
                {
                    throw new ArgumentException("This ingredient doesn't exist.", nameof(value));
                }
                else
                    _topping4 = value;
            }
        }

        public string Topping5
        {
            get { return _topping5; }
            set
            {
                // if the search key isn't in the dictionary
                if (!IngredientDetails.ContainsKey(value))
                {
                    throw new ArgumentException("This ingredient doesn't exist.", nameof(value));
                }
                else
                    _topping5 = value;
            }
        }

        public double Cost
        {
            get { return _cost; }
            set
            {

            }
        }
    }
}
