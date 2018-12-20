using Microsoft.EntityFrameworkCore;
using PizzaStore.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.Context
{
    /// <summary>
    ///     This repository's purpose is to manage data access across User, Store,
    ///     Transactions, TransactionOrder, and Inventory
    /// </summary>
    public class PizzaStoreRepository : IPizzaStoreRepository
    {
        private readonly PizzaDBContext _db;

        // initialize new pizza store repository
        public PizzaStoreRepository(PizzaDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void AddOrder(Library.TransactionsLib transaction)
        {
            throw new NotImplementedException();
        }

        public void AddPizza(Library.TransactionOrderLib order)
        {
            TransactionOrder transactionOrder = new TransactionOrder();
            transactionOrder.Size = order.Size;
            transactionOrder.Topping1 = order.Topping1;
            transactionOrder.Topping2 = order.Topping2;
            transactionOrder.Topping3 = order.Topping3;
            transactionOrder.Topping4 = order.Topping4;
            transactionOrder.Topping5 = order.Topping5;
            transactionOrder.Cost = order.Cost;
        }

        public void AddRepeatOrder(Library.TransactionsLib transaction)
        {
            throw new NotImplementedException();
        }

        public void AddStore(Library.StoreLib store)
        {
            Store newStore = new Store();
            newStore.Name = store.Name;
            newStore.Stock = store.Stock;
        }

        public bool CheckStore(Library.StoreLib store)
        {
            if (_db.Store.Where(s => s.Name == store.Name).ToList().Count == 0)
            {
                return false;
            }
            else
                return true;
        }

        public void AddUser(Library.UserLib user)
        {
            Users newUser = new Users();
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            _db.Add(newUser);
        }

        public bool CheckUser(UserLib user)
        {
            // if there are no users with the provided first and last name
            if (_db.Users.Where(u => u.FirstName == user.FirstName && u.LastName == user.LastName).ToList().Count == 0)
            {
                return false;
            }
            else
                return true; // if there is a match
        }

        public IEnumerable<Library.InventoryLib> GetInventory()
        {
            IList<InventoryLib> inventory = new List<InventoryLib>();
            foreach (var ingredient in _db.Inventory.ToList())
            {
                inventory.Add(CreateInventoryFromDB(ingredient));
            }
            return inventory;
        }

        private InventoryLib CreateInventoryFromDB(Inventory inventory)
        {
            return new InventoryLib(inventory.IngredientName, inventory.Price);
        }

        public void DeleteUser(Library.UserLib userid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.TransactionsLib> GetCheapestTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.TransactionsLib> GetEarliestTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.TransactionsLib> GetLatestTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.TransactionsLib> GetMostExpensiveTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionOrderLib> GetTransactionOrders()
        {
            IList<TransactionOrderLib> orders = new List<TransactionOrderLib>();
            foreach (var order in _db.TransactionOrder.ToList())
            {
                orders.Add(CreateTransactionOrderFromDB(order));
            }
            return orders;
        }

        private TransactionOrderLib CreateTransactionOrderFromDB(TransactionOrder order)
        {
            return new TransactionOrderLib(order.PizzaId, order.Size, order.Topping1, order.Topping2,
                order.Topping3, order.Topping4, order.Topping5, order.Cost);
        }

        public IEnumerable<Library.TransactionsLib> GetTransactions()
        {
            IList<TransactionsLib> transactions = new List<TransactionsLib>();
            foreach (var transaction in _db.Transactions.ToList())
            {
                transactions.Add(CreateTransactionFromDB(transaction));
            }
            return transactions;
        }

        private TransactionsLib CreateTransactionFromDB(Transactions transaction)
        {
            return new TransactionsLib(transaction.OrderId, transaction.PizzaId, transaction.UserId, transaction.StoreName);
        }

        public IEnumerable<Library.UserLib> GetUsers()
        {
            IList<UserLib> user = new List<UserLib>();
            foreach (var person in _db.Users.ToList())
            {
                user.Add(CreateUserFromDB(person));
            }
            return user;
        }

        private UserLib CreateUserFromDB(Users person)
        {
            return new UserLib(person.Id, person.FirstName, person.LastName);
        }

        public IEnumerable<StoreLib> GetStores()
        {
            IList<StoreLib> stores = new List<StoreLib>();
            foreach (var store in _db.Store.ToList())
            {
                stores.Add(CreateStoreFromDB(store));
            }
            return stores;
        }

        private StoreLib CreateStoreFromDB(Store store)
        {
            return new StoreLib(store.Name, store.Stock);
        }

        // saves data to source
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
