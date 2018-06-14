using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	class DrinkItem : Item
	{
		public DrinkItem(string name, decimal cost)
			: base(name, cost)
		{

		}

		public override void MakeSound()
		{
			Console.WriteLine("Glug Glug, Yum!");
		}
	}
}
