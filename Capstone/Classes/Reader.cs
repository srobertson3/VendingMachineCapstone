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
                        List<Item> items = GetItemsFromLine(lineSplit);

                        vendingItems.Add(key, items);                        
					}
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.Message);
			}

			return vendingItems;
		}

        private List<Item> GetItemsFromLine(List<string> lineSplit)
        {
            List<Item> items = new List<Item>();
            const int DefaultQuantity = 5;
            const int Col_Name = 0;
            const int Col_Price = 1;
            const int Col_Type = 2;

            Dictionary<string, Type> productTypes = new Dictionary<string, Type>()
            {
                {"Chip", typeof(ChipItem) },
                {"Drink", typeof(DrinkItem) },
                {"Gum", typeof(GumItem) },
                {"Candy", typeof(CandyItem) }
            };

            Type typeToCreate = productTypes[lineSplit[Col_Type]];

            for (int i = 0; i < DefaultQuantity; i++)
            {
                Item item = (Item)Activator.CreateInstance(typeToCreate, lineSplit[Col_Name], decimal.Parse(lineSplit[Col_Price]));
                items.Add(item);
            }

            // I don't know of a better way 
            //if (lineSplit[Col_Type] == "Chip")
            //{
            //    for (int i = 0; i < DefaultQuantity; i++)
            //    {
            //        ChipItem chips = new ChipItem(lineSplit[Col_Name], decimal.Parse(lineSplit[Col_Price]));
            //        items.Add(chips);
            //    }
            //}
            //else if (lineSplit[Col_Type] == "Drink")
            //{
            //    for (int i = 0; i < DefaultQuantity; i++)
            //    {
            //        DrinkItem drinks = new DrinkItem(lineSplit[Col_Name], decimal.Parse(lineSplit[Col_Price]));
            //        items.Add(drinks);
            //    }
            //}
            //else if (lineSplit[Col_Type] == "Gum")
            //{
            //    for (int i = 0; i < DefaultQuantity; i++)
            //    {
            //        GumItem gum = new GumItem(lineSplit[Col_Name], decimal.Parse(lineSplit[Col_Price]));
            //        items.Add(gum);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < DefaultQuantity; i++)
            //    {
            //        CandyItem candy = new CandyItem(lineSplit[Col_Name], decimal.Parse(lineSplit[Col_Price]));
            //        items.Add(candy);
            //    }
            //}

            return items;
        }
    }
}

