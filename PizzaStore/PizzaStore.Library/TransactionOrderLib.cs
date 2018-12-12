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

    public class TransactionOrderLib
    {
        // a dictionary that takes objects from the Inventory class as the key and value pair,
        // in this case being the IngredientName and Price
        public Dictionary<InventoryLib, InventoryLib> IngredientDetails { get; set; } = new Dictionary<InventoryLib, InventoryLib>();

        public int PizzaId { get; set; }

        private string _size;
        private string _topping1;
        private string _topping2;
        private string _topping3;
        private string _topping4;
        private string _topping5;
        private double _cost;

        // returns pizza size
        // sets pizza size, must be a valid size choice
        public string Size
        {
            get { return _size; }
            set
            {
                // if the value does not equal these options
                if (value == "S" || value == "s" || value == "M" || value == "m" || value == "L" || value == "l")
                {
                    _size = value;
                }
                else
                    throw new ArgumentException("Must be a valid size option!", nameof(value));
            }
        }

        //these only need to check to see if the naming convention is valid
        public string Topping1
        {
            get { return _topping1; }
            set
            {
                // if the ingredient name is empty
                if (value.Length == 0)
                {
                    throw new ArgumentException("This topping name isn't valid.", nameof(value));
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
                // if the ingredient name is empty
                if (value.Length == 0)
                {
                    throw new ArgumentException("This topping name isn't valid.", nameof(value));
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
                // if the ingredient name is empty
                if (value.Length == 0)
                {
                    throw new ArgumentException("This topping name isn't valid.", nameof(value));
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
                // if the ingredient name is empty
                if (value.Length == 0)
                {
                    throw new ArgumentException("This topping name isn't valid.", nameof(value));
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
                // if the ingredient name is empty
                if (value.Length == 0)
                {
                    throw new ArgumentException("This topping name isn't valid.", nameof(value));
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
                // if the cost is less than 0
                if (value < 0)
                {
                    throw new ArgumentException("Not a valid price.");
                }
                else
                    _cost = value;
            }
        }
    }
}
