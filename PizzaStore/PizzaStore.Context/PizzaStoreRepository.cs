using Microsoft.EntityFrameworkCore;
using PizzaStore.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.Context
{
    public class PizzaStoreRepository : IPizzaStoreRepository
    {
        public void AddOrder(Library.Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public void AddPizza(Library.TransactionOrder order)
        {
            throw new NotImplementedException();
        }

        public void AddRepeatOrder(Library.Transactions transaction)
        {
            throw new NotImplementedException();
        }

        public void AddStore(Library.Store store)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void CheckStoreStock(Library.Store store)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User userid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Transactions> GetCheapestTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Transactions> GetEarliestTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Transactions> GetLatestTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Transactions> GetMostExpensiveTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Library.Transactions> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
