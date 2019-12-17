using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Shop
    {

        static List<GameObject> itemsForSale = new List<GameObject>();

        public static List<GameObject> ItemsForSale { get => itemsForSale; set => itemsForSale = value; }
    }
}
