using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class CandyItem : Item
	{
		public CandyItem(string name, decimal cost)
			: base(name, cost)
		{

		}

		public override string MakeSound()
		{
			return "Munch Munch, Yum!";
		}
	}
}
