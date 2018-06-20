using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
	public class User
	{
        public List<Item> Cart { get; private set; } = new List<Item>();

		public User(List<Item> cart)
		{
			Cart = cart;
		}

	}
}
