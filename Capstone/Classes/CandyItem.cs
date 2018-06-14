using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	class CandyItem : Item
	{
		public CandyItem(string name, decimal cost)
			: base(name, cost)
		{

		}

		public override void MakeSound()
		{
			Console.WriteLine("Munch Munch, Yum!");
		}
	}
}
