using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class ShopperManager
    {
        private static ShopperManager instance;
        public static ShopperManager Instance
        {

            get
            {
                if (instance == null)
                    instance = new ShopperManager();

                return instance;
            }
        }

        static SmarterLinkedList<GameObject> shoppers = new SmarterLinkedList<GameObject>();

        public static SmarterLinkedList<GameObject> Shoppers { get => shoppers; set => shoppers = value; }

        public static void GetMoving()
        {
            foreach (GameObject go in shoppers)
            {
                go.ShopperAi.FindPathToGoal();
            }
        }
    }
}
