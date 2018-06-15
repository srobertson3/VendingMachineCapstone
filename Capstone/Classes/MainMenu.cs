using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class MainMenu
	{
		public void Display()
		{
			Reader r = new Reader();
			Dictionary<string, List<Item>> inventory = r.ReadVendingMachineItems();

			VendingMachine machine = new VendingMachine(inventory);

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Main Menu");
				Console.WriteLine("(1) Display vending machine items");
				Console.WriteLine("(2) Purchase");

				Console.WriteLine("What would you like to do? ");
				string input = Console.ReadLine();

				if (input == "1")
				{
					Console.Clear();
					machine.DisplayInventory();
				}
				else if (input == "2")
				{
					SubMenu submenu = new SubMenu();
					submenu.Display(machine);

				}
			}
		}
	}
}
