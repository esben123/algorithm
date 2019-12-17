using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Grid
    {
        private Node[,] allNodes;
        string testString ="";

        public void CreateGrid()
        {
            allNodes = new Node[(int)GameWorld.ShopDimensions.X, (int)GameWorld.ShopDimensions.Y];

            for (int y = 1; y < GameWorld.ShopDimensions.Y; y++)
            {
                for (int x = 1; x < GameWorld.ShopDimensions.X; x++)
                {
                    bool isFilled = GameWorld.ShopGo[x, y].Item == Item.Nothing;
                    allNodes[x,y] = new Node(new Point(x, y), isFilled);

                    testString += isFilled.ToString();
                    testString += " ";
                }
                testString += "\n";

            }

            Console.WriteLine(testString);

        }


       


    }
}
