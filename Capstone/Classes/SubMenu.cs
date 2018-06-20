using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class SubMenu
    {
        public void Display(VendingMachine machine)
        {

            User user = new User(new List<Item>());
            Writer log = new Writer();

            while (true)
            {
                Console.Clear();

                if (user.Cart.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Items you've purchased: ");

                    foreach (var item in user.Cart)
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Purchase Menu");
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money ");
                Console.WriteLine("(2) Select Product ");
                Console.WriteLine("(3) Finish Transaction ");
                Console.WriteLine();
                Console.WriteLine($"Current Money Provided {machine.Balance}");
                Console.WriteLine();

                Console.WriteLine("What would you like to do? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    ExecuteOption1(machine, log);
                }
                if (input == "2")
                {
                    ExecuteOption2(machine, log, user);
                }
                if (input == "3")
                {
                    ExecuteOption3(machine, log, user);
                }
            }
        }
        /// <summary>
        /// Allows you to feed in money
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="log"></param>
        void ExecuteOption1(VendingMachine machine, Writer log)
        {
            Console.WriteLine();
            Console.WriteLine("Press 'N' when you're finished feeding money.");
            Console.WriteLine("Please only feed in whole dollar amounts. ");
            while (true)
            {
                Console.WriteLine("How much money would you like to feed in?");
                Console.Write(">>");
                string money = Console.ReadLine().ToUpper();
                Console.WriteLine();

                if (money != "N")
                {
                    if (decimal.TryParse(money, out decimal feed))
                    {
                        log.Log($"FEED MONEY", machine.Balance, machine.Balance + feed);
                        machine.FeedMoney(feed);
                        Console.WriteLine($"Current Money Provided {machine.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that wasn't a valid choice! Please try something else!");
                    }                    
                }
                else
                {
                    break;
                }
            }

        }

        /// <summary>
        /// Allow you to make purchases
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="log"></param>
        /// <param name="user"></param>
        void ExecuteOption2(VendingMachine machine, Writer log, User user)
        {
            Console.Clear();
            machine.DisplayInventory();
            Console.WriteLine();

            Console.WriteLine("What product would you like to purchase?");
            Console.Write(">>");

            string selection = Console.ReadLine().ToUpper();
            
            if (machine.Inventory.ContainsKey(selection))
            {
                if (machine.Inventory[selection].Count <= 0)
                {
                    Console.WriteLine("Sorry, that item is SOLD OUT!");
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    if (machine.Balance >= machine.Inventory[selection][0].Cost)
                    {
                        log.Log($"{machine.Inventory[selection][0].Name}", machine.Balance, machine.Balance - machine.Inventory[selection][0].Cost);
                        machine.Vend(selection, user);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you don't have enough money for that!");
                        System.Threading.Thread.Sleep(3000);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, that product code does not exist!");
                System.Threading.Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Allows you to receive & "eat" your items and get your change
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="log"></param>
        /// <param name="user"></param>
        void ExecuteOption3(VendingMachine machine, Writer log, User user)
        {
            Console.Clear();
            Console.WriteLine();
            log.Log($"RETURN CHANGE", machine.Balance, 0);
            Console.WriteLine();

            Console.WriteLine($"{machine.ReturnChange()}");
            Console.WriteLine();

            foreach (var item in user.Cart)
            {
                Console.WriteLine(item.MakeSound());
                System.Threading.Thread.Sleep(1000);
            }

            user.Cart.Clear();
            Console.WriteLine();
            Console.WriteLine("Thank you for snacking with us!");
            System.Threading.Thread.Sleep(5000);
        }
    }
}
