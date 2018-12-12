using System;
using System.Collections.Generic;

namespace PizzaStore.Context
{
    public partial class Users
    {
        public Users()
        {
            Transactions = new HashSet<Transactions>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
