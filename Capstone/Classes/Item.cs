using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public abstract class Item
	{
		public string Name { get; set; }
		public decimal Cost { get; set; }

		public Item(string name, decimal cost)
		{
			Name = name;
			Cost = cost;
		}

		public abstract void MakeSound();

	}
}
