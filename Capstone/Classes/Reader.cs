using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Capstone.Classes
{
	public class Reader
	{
		public Dictionary<string, List<Item>> ReadVendingMachineItems()
		{
			string path = Path.Combine(Environment.CurrentDirectory, "VendingMachineItems.csv");
			Dictionary<string, List<Item>> vendingItems = new Dictionary<string, List<Item>>();

			try
			{

				using (StreamReader sr = new StreamReader(path))
				{
					while (!sr.EndOfStream)
					{
						string line = sr.ReadLine();
						List<string> lineSplit = new List<string>(line.Split('|'));
						string key = lineSplit[0];
						lineSplit.RemoveAt(0);

						if (lineSplit[2] == "Chip")
						{
							List<Item> chipStock = new List<Item>();

							for (int i = 0; i < 5; i++)
							{
								ChipItem chips = new ChipItem(lineSplit[0], decimal.Parse(lineSplit[1]));
								chipStock.Add(chips);
							}
							vendingItems.Add(key, chipStock);
						}
						else if (lineSplit[2] == "Drink")
						{
							List<Item> drinkStock = new List<Item>();

							for (int i = 0; i < 5; i++)
							{
								DrinkItem drinks = new DrinkItem(lineSplit[0], decimal.Parse(lineSplit[1]));
								drinkStock.Add(drinks);
							}
							vendingItems.Add(key, drinkStock);
						}
						else if (lineSplit[2] == "Gum")
						{
							List<Item> gumStock = new List<Item>();

							for (int i = 0; i < 5; i++)
							{
								GumItem gum = new GumItem(lineSplit[0], decimal.Parse(lineSplit[1]));
								gumStock.Add(gum);
							}
							vendingItems.Add(key, gumStock);
						}
						else
						{
							List<Item> candyStock = new List<Item>();

							for (int i = 0; i < 5; i++)
							{
								CandyItem candy = new CandyItem(lineSplit[0], decimal.Parse(lineSplit[1]));
								candyStock.Add(candy);
							}
							vendingItems.Add(key, candyStock);
						}
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}

			return vendingItems;
		}
	}
}

