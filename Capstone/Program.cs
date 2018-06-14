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
			Reader r = new Reader();

			foreach (KeyValuePair<string, List<Item>> kvp in r.ReadVendingMachineItems())
			{
				Console.WriteLine(kvp.Key, kvp.Value[0]);
			}
        }
    }
}
