﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public enum Item
    {
        Nothing = 0,
        Spear = 1,
        Armour = 2,
        Helmet = 3,
        Necronomicon = 4,
        CallOfCthulhu = 5,
        Wall = 6,
        Register = 7
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
                itemIndex = rnd.Next(1, 6);
                item = (Item)itemIndex;
                itemsToPurchase.Add(item);
            }
        }

        public string GetList()
        {
            string list = "";
           
            for (int i = 0; i < itemsToPurchase.Count; i++)
            {
                list += itemsToPurchase[i].ToString();
                if (i < itemsToPurchase.Count -1)
                    list += "\n";
            }
            return list;
        }

        public Item itemToPurchase()
        {
            return itemsToPurchase[0];
        }

        public void RemoveItem()
        {
            itemsToPurchase.RemoveAt(0);
            Parent.FontRenderer.SetContent(GetList());
        }
    }
}
