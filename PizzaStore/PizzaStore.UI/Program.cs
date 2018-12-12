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
            Console.WriteLine("Pizza Ordering App");

            while (run)
            {
                Console.WriteLine();

                Console.WriteLine("L:\tLog into an existing user.");
                Console.WriteLine("C:\tCreate a new user");
                Console.WriteLine("E:\tExit app.");
                var input = Console.ReadLine();

                if (input == "L")
                {
                    Console.WriteLine();
                    Console.WriteLine("Please input your first name: ");
                    var firstname = Console.ReadLine();
                    Console.WriteLine("Please input your last name: ");
                    var lastname = Console.ReadLine();

                    UserLib user = new UserLib(0, firstname, lastname);
                    var listusers = pizzaStoreRepository.CheckUser(user);
                    if (listusers)
                    {
                        Console.WriteLine("Logged in.");
                        Console.WriteLine();

                        Console.WriteLine("H:\tShow order history.");
                        Console.WriteLine("N:\tCreate a new order.");
                        Console.WriteLine("E:]tLog out.");
                        var input1 = Console.ReadLine();

                        if (input1 == "H")
                        {
                            var orderHistory = pizzaStoreRepository.GetTransactions().ToList();
                            
                            if (orderHistory.Count == 0)
                            {
                                Console.WriteLine("No order history");
                            }
                            
                            for (var i = 1; i <= orderHistory.Count; i++)
                            {
                                var order = orderHistory[i - 1];
                                var orderHistoryString = $"{i}: OrderID: {order._orderId} PizzaID: {order.PizzaId} UserID: {order.UserId}" +
                                   $" Location: {order.StoreName} Date: {order._orderTime}";
                                Console.WriteLine(orderHistoryString);
                            }

                        }
                        else if (input1 == "N")
                        {

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
