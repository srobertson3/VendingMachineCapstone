using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public abstract class Item
	{
		string Name { get; set; }
		decimal Cost { get; set; }

		public Item(string name, decimal cost)
		{
			Name = name;
			Cost = cost;
		}

		public abstract void MakeSound();

	}
}
