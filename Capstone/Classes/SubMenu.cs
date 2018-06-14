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

			while (true)
			{
				Console.Clear();
				Console.WriteLine();
				Console.WriteLine("Purchase Menu");
				Console.WriteLine("(1) Feed Money ");
				Console.WriteLine("(2) Select Product ");
				Console.WriteLine("(3) Finish Transaction ");
				Console.WriteLine($"Current Money Provided {machine.Balance}");

				Console.WriteLine("What would you like to do? ");
				string input = Console.ReadLine();

				if (input == "1")
				{
					Console.WriteLine("Press 'N' when you're finished feeding money.");
					Console.WriteLine("Please only feed in whole dollar amounts. ");
					while (true)
					{
						Console.WriteLine("How much money would you like to feed in?");
						string money = Console.ReadLine().ToUpper();

						if (money != "N")
						{
							decimal feed = decimal.Parse(money);
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
				
					Console.WriteLine("What product would you like to purchase?");

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
					}
				}
			}	
		}
	}
}
