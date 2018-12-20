using Microsoft.EntityFrameworkCore;
using PizzaStore.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using PC = PizzaStore.Context;

namespace PizzaStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaStoreBuilder = new DbContextOptionsBuilder<PC.PizzaDBContext>();
            pizzaStoreBuilder.UseSqlServer(SecretConfiguration.ConnectionString);
            var pizzaStore = pizzaStoreBuilder.Options;

            var dbContext = new PC.PizzaDBContext(pizzaStore);
            IPizzaStoreRepository pizzaStoreRepository = new PC.PizzaStoreRepository(dbContext);

            bool run = true;

            while (run)
            {
                Console.WriteLine("Pizza Ordering App");
                Console.WriteLine();

                Console.WriteLine("L:\tLog into an existing user.");
                Console.WriteLine("C:\tCreate a new user");
                Console.WriteLine("E:\tExit app.");
                var input = Console.ReadLine();

                if (input == "L")
                {
                    Console.Clear();
                    Console.WriteLine("List of existing users:");

                    var userList = pizzaStoreRepository.GetUsers().ToList();
                    if (userList.Count == 0)
                    {
                        Console.WriteLine("No users in the database.");
                        break;
                    }
                    else
                    {
                        for (var i = 1; i<= userList.Count; i++)
                        {
                            var person = userList[i - 1];
                            var personString = $"ID: {person.Id} Name: {person.FirstName} {person.LastName}";
                            Console.WriteLine(personString);
                        }
                    }

                    Console.WriteLine("Logging in...");
                    Console.WriteLine();
                    Console.WriteLine("Please input your first name: ");
                    var firstname = Console.ReadLine();
                    Console.WriteLine("Please input your last name: ");
                    var lastname = Console.ReadLine();

                    UserLib user = new UserLib(0, firstname, lastname);
                    var listusers = pizzaStoreRepository.CheckUser(user);
                    Console.Clear();
                    if (listusers)
                    {
                        Console.WriteLine("Logged in.");
                        Console.WriteLine();

                        Console.WriteLine("H:\tShow order history.");
                        Console.WriteLine("N:\tCreate a new order.");
                        Console.WriteLine("E:\tLog out.");
                        var input1 = Console.ReadLine();

                        if (input1 == "H")
                        {
                            var orderHistory = pizzaStoreRepository.GetTransactions().ToList();
                            /*
                            if (orderHistory.Count == 0)
                            {
                                Console.WriteLine("No order history");
                            }
                            */
                            for (var i = 1; i <= orderHistory.Count; i++)
                            {
                                var order = orderHistory[i - 1];
                                if (user.Id == order.UserId)
                                {
                                    var orderHistoryString = $"{i}: OrderID: {order._orderId} PizzaID: {order.PizzaId} UserID: {order.UserId}" +
                                        $" Location: {order.StoreName} Date: {order._orderTime}";
                                    Console.WriteLine(orderHistoryString);

                                    var pizzaOrder = pizzaStoreRepository.GetTransactionOrders().ToList();
                                    for (var j = 1; j <= pizzaOrder.Count; j++)
                                    {
                                        var pOrder = pizzaOrder[j - 1];
                                        var pizzaOrderString = $"\t{j}: PizzaID: {pOrder.PizzaId} Size: {pOrder.Size} Toppings: {pOrder.Topping1}, " +
                                            $"{pOrder.Topping2}, {pOrder.Topping3}, {pOrder.Topping4}, {pOrder.Topping5} Cost: ${pOrder.Cost}";
                                        Console.WriteLine(pizzaOrderString);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("User has no order history.");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else if (input1 == "N")
                        {
                            Console.WriteLine("Retreiving store information...");
                            // check database for existing stores
                            var storeList = pizzaStoreRepository.GetStores().ToList();
                            if (storeList.Count == 0)
                            {
                                Console.WriteLine("No stores stored in the database.");
                                // prompted to create a store
                            }
                            for (var i = 1; i <= storeList.Count; i++)
                            {
                                var stores = storeList[i - 1];
                                var storeString = $"Store Name: {stores.Name} Stock: {stores.Stock}";
                                Console.WriteLine(storeString);
                            }
                            // select an existing store or create one
                            Console.WriteLine();
                            Console.WriteLine("S:\tSelect a store.");
                            Console.WriteLine("C:\tCreate a new store.");
                            var input2 = Console.ReadLine();

                            if (input2 == "C")
                            {
                                Console.Clear();
                                Console.WriteLine("Input a store name:");
                                var userstoreName = Console.ReadLine();
                                Console.WriteLine($"Please set the amount of ingredients for {userstoreName}.");
                                var userstoreStock = Convert.ToInt32(Console.ReadLine());

                                StoreLib store = new StoreLib(userstoreName, userstoreStock);
                                pizzaStoreRepository.AddStore(store);
                                pizzaStoreRepository.Save();
                                Console.WriteLine("Store added.");
                            }
                            else if (input2 == "S")
                            {
                                Console.Clear();
                                Console.WriteLine("Input a store name:");
                                var userstoreName = Console.ReadLine();

                                StoreLib store = new StoreLib(userstoreName, 0);
                                var validStore = pizzaStoreRepository.CheckStore(store);
                                
                                if (validStore)
                                {
                                    Console.WriteLine("Would you like to place an order? (Y/N)");
                                    var ordering = Console.ReadLine();

                                    if (ordering == "Y")
                                    {
                                        // need to check inventory for calculated cost
                                        decimal pricing = 0;
                                        Console.WriteLine("What size pizza? L($40) M($35) S($30)");
                                        var userSize = Console.ReadLine();
                                        Console.WriteLine("Here is a list of available toppings:");


                                    }
                                    else if (ordering == "N")
                                    {
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Invalid input.");
                                }
                                else
                                {
                                    Console.WriteLine("Not a valid store.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please input a valid command.");
                            }

                            // create order
                            // try to place order, if not enough stock, reject
                        }
                        else if (input1 == "E")
                        {
                            run = false;
                        }
                        else
                            Console.WriteLine("Please input a valid command.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid user.");
                        run = false;
                    }
                }
                else if (input == "C")
                {
                    Console.Clear();
                    Console.WriteLine("Creating a new user...");
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid first name: ");
                    var firstname = Console.ReadLine();
                    Console.WriteLine("Please enter a valid last name: ");
                    var lastname = Console.ReadLine();

                    UserLib user = new UserLib(0, firstname, lastname);
                    pizzaStoreRepository.AddUser(user);
                    pizzaStoreRepository.Save();
                    Console.WriteLine("User added.");
                }
                else if (input == "E")
                {
                    run = false;
                }
                else
                    Console.WriteLine("Please input a valid command.");
            }

            // prevents console app from automatically closing
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
