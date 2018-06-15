using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
	public class Writer
	{
		public Writer() { }

		public void Log(string action, decimal balance, decimal endingBalance)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter("Log.txt", true)) 
				{
					sw.WriteLine($"{DateTime.Now} {action.PadLeft(10)}:   {balance :C}{"".PadLeft(10)}{endingBalance :C}");
					
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
