using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
	public class GumItem : Item
	{
		public GumItem(string name, decimal cost)
			: base(name, cost)
		{
		}

		public override void MakeSound()
		{
			Console.WriteLine("Chew Chew, Yum!");
		}
	}
}
