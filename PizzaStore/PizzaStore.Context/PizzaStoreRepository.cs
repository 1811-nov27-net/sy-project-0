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
            throw new NotImplementedException();
        }

        public void AddRepeatOrder(Library.TransactionsLib transaction)
        {
            throw new NotImplementedException();
        }

        public void AddStore(Library.StoreLib store)
        {
            throw new NotImplementedException();
        }

        public void AddUser(Library.UserLib user)
        {
            throw new NotImplementedException();
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

        public void CheckStoreStock(Library.StoreLib store)
        {
            throw new NotImplementedException();
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
            return new StoreLib(store.Name);
        }

        // saves data to source
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
