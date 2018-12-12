using System;
using System.Collections.Generic;

namespace PizzaStore.Context
{
    public partial class Store
    {
        public Store()
        {
            Transactions = new HashSet<Transactions>();
        }

        public string Name { get; set; }
        public int? OrderId { get; set; }
        public int? Stock { get; set; }

        public virtual TransactionOrder Order { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
