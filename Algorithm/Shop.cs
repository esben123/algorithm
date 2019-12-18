using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Shop
    {

        static SmarterLinkedList<GameObject> ShopElements = new SmarterLinkedList<GameObject>();

        public static SmarterLinkedList<GameObject> ItemsForSale { get => ShopElements; set => ShopElements = value; }

        public static Point GetPoint(Item item)
        {
            foreach (GameObject go in ShopElements)
            {
                if (go.Item == item)
                    return go.Transform.GridPos;
            }
            return Point.Zero;
        }
    }
}
