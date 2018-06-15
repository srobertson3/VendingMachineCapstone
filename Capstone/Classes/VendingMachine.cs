using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class VendingMachine
	{
		public Dictionary<string, List<Item>> Inventory { get; set; }

		public decimal Balance { get; private set; }

		public VendingMachine(Dictionary<string, List<Item>> inventory)
		{
			Inventory = inventory;
			Balance = 0;
		}

		public void DisplayInventory()
		{
			foreach (var kvp in Inventory)
			{
				if (kvp.Value.Count == 0)
				{
					Console.WriteLine($"{kvp.Key} | Sorry, this item is SOLD OUT!!");
				}
				else
				{
					Console.WriteLine($"{kvp.Key} | {kvp.Value[0].Name} | {kvp.Value[0].Cost}");
				}
			}
		}

		public void FeedMoney(decimal amount)
		{
			if (amount < 0 || amount - Math.Floor(amount) > 0)
			{
				Console.WriteLine("Sorry, that's not a valid amount!");
				System.Threading.Thread.Sleep(3000);
			}
			else
			{
				Balance += amount;
			}
		}

		public void Vend(string slot, User user)
		{
			Balance -= Inventory[slot][0].Cost;
			user.Cart.Add(Inventory[slot][0]);
			Inventory[slot].RemoveAt(0);
		}

		public string ReturnChange()
		{
			int quarters = 0;
			int dimes = 0;
			int nickels = 0;

			while (Balance != 0)
			{
				if (Balance >= .25M)
				{
					quarters++;
					Balance -= .25M;
				}
				else if (Balance >= .10M)
				{
					dimes++;
					Balance -= .10M;
				}
				else if (Balance >= .05M)
				{
					nickels++;
					Balance -= .05M;
				}
			}

			string change = $"Your change is: {quarters} quarters, {dimes} dimes, and {nickels} nickels.";
			return change;
		}
	}
}
