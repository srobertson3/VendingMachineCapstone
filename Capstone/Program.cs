using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
			MainMenu mainMenu = new MainMenu();
			mainMenu.Display();



			//var firstItematA1 = inventory["A1"][0].Name; //if we know the item
			//foreach (var kvp in inventory)
			//{
			//	string slot = kvp.Key;
			//	Item firstItem = kvp.Value.FirstOrDefault();

			//	if (firstItem == null)
			//	{
			//		// sold out
			//	}
			//}

		}
    }
}
