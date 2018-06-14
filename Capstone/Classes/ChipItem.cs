using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class ChipItem : Item
	{
		public ChipItem(string name, decimal cost)
			: base(name, cost)
		{

		}

		public override void MakeSound()
		{
			Console.WriteLine("Crunch Crunch, Yum!");
		}
	}
}
