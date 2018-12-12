using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    /// <summary>
    ///     Transactions is the main brain, in that it is the starting reference to
    ///     all the other tables, since it requires a UserID, PizzaID (to TransactionOrder),
    ///     and a Store ID (in this case, the name of the store)
    ///     For OrderTime, we are pulling the computer's current time, and we can convert it
    ///     to a string format using the DateTime struct if we want to output it to the user
    ///     otherwise, according to stackoverflow it is possible to save the DateTime object
    ///     to the SQL database, as long as the type of OrderTime is datetime (in our case,
    ///     it is datetime2)
    /// </summary>

    public class TransactionsLib
    {
        public int _orderId { get; set; }
        public DateTime _orderTime { get; set; }

        private int _pizzaId;
        private int _userId;
        private string _storeName;

        public TransactionsLib(int orderid, int pizzaid, int userid, string storename)
        {
            _orderId = orderid;
            _pizzaId = pizzaid;
            _userId = userid;
            _storeName = storename;
        }

        public int PizzaId
        {
            get { return _pizzaId; }
            set
            {
                // if the input value is less than 10 (since the first pizza order starts with a default
                // ID of 10, and incrememnts by 10 in the database)
                if (value < 10)
                {
                    throw new ArgumentException("Must be a valid Pizza ID.");
                }
                else
                    _pizzaId = value;
            }
        }

        public int UserId
        {
            get { return _userId; }
            set
            {
                // if the input value is less than or equal to 0
                if (value <= 0)
                {
                    throw new ArgumentException("Must be a valid User ID.");
                }
                else
                    _userId = value;
            }
        }

        public string StoreName
        {
            get { return _storeName; }
            set
            {
                // if the input string is empty
                if (value.Length == 0)
                {
                    throw new ArgumentException("Store name must not be empty.", nameof(value));
                }
                else
                    _storeName = value;
            }
        }
    }
}
