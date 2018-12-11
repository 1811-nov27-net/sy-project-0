using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    /// <summary>
    ///     User has:
    ///         ID
    ///         FirstName
    ///         LastName
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        private string _firstName;
        private string _lastName;

        // returns firstname
        // sets firstname, must not be empty
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                // if the string length of the first name is 0
                if (value.Length == 0)
                {
                    throw new ArgumentException("First name must not be empty.", nameof(value));
                }
                else
                    _firstName = value;
            }
        }

        // returns lastname
        // sets lastname, must not be empty
        public string LastName
        {
            get { return _lastName; }
            set
            {
                // if the string length of the last name is 0
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last name must not be empty.", nameof(value));
                }
                else
                    _lastName = value;
            }
        }
    }
}
