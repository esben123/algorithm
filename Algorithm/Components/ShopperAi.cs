using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class ShopperAi : Component
    {
        

        public Node GetGoal()
        {
            Grid grid = new Grid();

            Item itemTofind = Parent.ShoppingList.itemToPurchase();
          //  Console.WriteLine(itemTofind.ToString());
            return grid.FindNodeByItemType(itemTofind);
        }

    }
}
