using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    /// <summary>
    ///     This repository's purpose is to manage data access across User, Store,
    ///     Transactions, TransactionOrder, and Inventory
    /// </summary>
    public interface IPizzaStoreRepository
    {
        // output a list of users
        IEnumerable<User> GetUsers();

        // add a user
        void AddUser(User user);

        // delete a user by ID (not important atm)
        void DeleteUser(User userid);

        // display order history either a user or store
        IEnumerable<Transactions> GetTransactions();

        // display order history by:
        // earliest
        IEnumerable<Transactions> GetEarliestTransactions();
        // latest
        IEnumerable<Transactions> GetLatestTransactions();
        // cheapest
        IEnumerable<Transactions> GetCheapestTransactions();
        // most expensive
        IEnumerable<Transactions> GetMostExpensiveTransactions();

        // use previous order history as a new order
        void AddRepeatOrder(Transactions transaction);

        // new order
        void AddOrder(Transactions transaction);

        // add a store
        void AddStore(Store store);

        // create pizza
        void AddPizza(TransactionOrder order);

        // check store inventory for appropriate stock amount
        // if valid, saves order to DB and prints out order to user
        // if invalid, will prompt user to choose another store or create a store
        void CheckStoreStock(Store store);

        // saves data to database source
        void Save();
    }
}
