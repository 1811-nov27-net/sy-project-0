using System;
using System.Collections.Generic;

namespace PizzaStore.Context
{
    public partial class Transactions
    {
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int UserId { get; set; }
        public string StoreName { get; set; }
        public DateTime OrderTime { get; set; }

        public virtual TransactionOrder Pizza { get; set; }
        public virtual Store StoreNameNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}
