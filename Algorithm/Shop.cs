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

        static List<GameObject> ShopElements = new List<GameObject>();

        public static List<GameObject> ItemsForSale { get => ShopElements; set => ShopElements = value; }

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
