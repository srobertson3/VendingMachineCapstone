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
				Console.WriteLine();
				Console.WriteLine("Purchase Menu");
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
							decimal feed = decimal.Parse(money);
							log.Log($"FEED MONEY", machine.Balance, (machine.Balance + feed));

							machine.FeedMoney(feed);
							Console.WriteLine($"Current Money Provided {machine.Balance}");
						}
						else
						{
							break;
						}
					}
				}
				if (input == "2")
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
				if (input == "3")
				{
					Console.Clear();
					log.Log($"RETURN CHANGE", machine.Balance, 0);
					Console.WriteLine($"{machine.ReturnChange()}");
					foreach (var item in user.Cart)
					{
						Console.WriteLine(item.MakeSound());
						System.Threading.Thread.Sleep(1000);
					}
					Console.WriteLine("Thank you for snacking with us!");
					System.Threading.Thread.Sleep(5000);

				}
			}	
		}
	}
}
