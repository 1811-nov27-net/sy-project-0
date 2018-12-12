using System;
using System.Collections.Generic;

namespace PizzaStore.Context
{
    public partial class TransactionOrder
    {
        public TransactionOrder()
        {
            Store = new HashSet<Store>();
            Transactions = new HashSet<Transactions>();
        }

        public int PizzaId { get; set; }
        public string Size { get; set; }
        public string Topping1 { get; set; }
        public string Topping2 { get; set; }
        public string Topping3 { get; set; }
        public string Topping4 { get; set; }
        public string Topping5 { get; set; }
        public decimal Cost { get; set; }

        public virtual Inventory Topping1Navigation { get; set; }
        public virtual Inventory Topping2Navigation { get; set; }
        public virtual Inventory Topping3Navigation { get; set; }
        public virtual Inventory Topping4Navigation { get; set; }
        public virtual Inventory Topping5Navigation { get; set; }
        public virtual ICollection<Store> Store { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
