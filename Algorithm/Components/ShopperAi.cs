﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class ShopperAi : Component
    {
        Grid grid;

        public ShopperAi()
        {
           
            
        }

        public void FindPathToGoal()
        {
           
           grid = new Grid();
            Console.WriteLine("trying shlazzl");
            Item itemTofind = Parent.ShoppingList.itemToPurchase();
            //  Console.WriteLine(itemTofind.ToString());
            Node start = grid.FindnodeAtGridpos(Parent.Transform.GridPos);
            Node end = grid.FindNodeByItemType(itemTofind);

            Astar aStar = new Astar();
            aStar.FindPath(start, end, grid);
        }

    }
}
