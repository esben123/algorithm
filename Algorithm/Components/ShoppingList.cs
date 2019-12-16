using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public enum Item
    {
        Spear = 0,
        Armour = 1,
        Helmet = 2,
        Necronomicon = 3,
        CallOfCthulhu = 4
    }

        public class ShoppingList : Component
    {
        private Item item;
        private List<Item> itemsToPurchase = new List<Item>();
        private Random rnd = new Random(Environment.TickCount);
        private int itemIndex;
        private int nrOfItems;

        public ShoppingList()
        {
            nrOfItems = rnd.Next(1, 4);

            for (int i = 0; i < nrOfItems; i++)
            {
                itemIndex = rnd.Next(0, 5);
                item = (Item)itemIndex;
                itemsToPurchase.Add(item);
            }
            foreach (Item item in itemsToPurchase)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
