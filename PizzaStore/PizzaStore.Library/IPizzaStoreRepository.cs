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
        IEnumerable<UserLib> GetUsers();

        // add a user
        void AddUser(UserLib user);

        // delete a user by ID (not important atm)
        void DeleteUser(UserLib userid);

        // check if a user exists
        bool CheckUser(UserLib user);

        // display order history either a user or store
        IEnumerable<TransactionsLib> GetTransactions();

        // display order history by:
        // earliest
        IEnumerable<TransactionsLib> GetEarliestTransactions();
        // latest
        IEnumerable<TransactionsLib> GetLatestTransactions();
        // cheapest
        IEnumerable<TransactionsLib> GetCheapestTransactions();
        // most expensive
        IEnumerable<TransactionsLib> GetMostExpensiveTransactions();

        // use previous order history as a new order
        void AddRepeatOrder(TransactionsLib transaction);

        // new order
        void AddOrder(TransactionsLib transaction);

        // display order info
        IEnumerable<TransactionOrderLib> GetTransactionOrders();

        // output list of stores
        IEnumerable<StoreLib> GetStores();

        // add a store
        void AddStore(StoreLib store);

        // check if store exists
        bool CheckStore(StoreLib store);

        // create pizza
        void AddPizza(TransactionOrderLib order);

        // check store inventory for appropriate stock amount
        // if valid, saves order to DB and prints out order to user
        // if invalid, will prompt user to choose another store or create a store
        IEnumerable<InventoryLib> GetInventory();

        // saves data to database source
        void Save();
    }
}
