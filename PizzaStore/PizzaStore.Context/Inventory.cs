using System;
using System.Collections.Generic;

namespace PizzaStore.Context
{
    public partial class Inventory
    {
        public Inventory()
        {
            TransactionOrderTopping1Navigation = new HashSet<TransactionOrder>();
            TransactionOrderTopping2Navigation = new HashSet<TransactionOrder>();
            TransactionOrderTopping3Navigation = new HashSet<TransactionOrder>();
            TransactionOrderTopping4Navigation = new HashSet<TransactionOrder>();
            TransactionOrderTopping5Navigation = new HashSet<TransactionOrder>();
        }

        public string IngredientName { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<TransactionOrder> TransactionOrderTopping1Navigation { get; set; }
        public virtual ICollection<TransactionOrder> TransactionOrderTopping2Navigation { get; set; }
        public virtual ICollection<TransactionOrder> TransactionOrderTopping3Navigation { get; set; }
        public virtual ICollection<TransactionOrder> TransactionOrderTopping4Navigation { get; set; }
        public virtual ICollection<TransactionOrder> TransactionOrderTopping5Navigation { get; set; }
    }
}
