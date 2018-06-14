using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class VendingMachine
	{
		public Dictionary<string, List<Item>> Inventory { get; set; }

		public decimal Balance { get; private set; }


	}
}
