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

			for (int i = 0; i < 3; i++)
			{
				Console.Clear();
				System.Threading.Thread.Sleep(750);
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("                         Welcome to: ");
				System.Threading.Thread.Sleep(750);
			}

			Console.Clear();
			Console.WriteLine(@"__      __            _               __  __       _   _        _____  ___   ___");
			Console.WriteLine(@"\ \    / /           | |             |  \/  |     | | (_)      | ____|/ _ \ / _ \ ");
			Console.WriteLine(@" \ \  / /__ _ __   __| | ___  ______ | \  / | __ _| |_ _  ___  | |__ | | | | | | |");
			Console.WriteLine(@"  \ \/ / _ \ '_ \ / _` |/ _ \ ______ | |\/| |/ _` | __| |/ __| |___ \| | | | | | |");
			Console.WriteLine(@"   \  /  __/ | | | (_| | (_) |       | |  | | (_| | |_| | (__   ___) | |_| | |_| |");
			Console.WriteLine(@"    \/ \___|_| |_|\__,_|\___/        |_|  |_|\__,_|\__|_|\___| |____/ \___/ \___/ ");

			while (true)
			{
				Console.WriteLine();
				Console.WriteLine("Main Menu");
				Console.WriteLine("(1) Display vending machine items");
				Console.WriteLine("(2) Purchase");
				Console.WriteLine();

				Console.WriteLine("What would you like to do? ");
				Console.WriteLine(">>");
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
