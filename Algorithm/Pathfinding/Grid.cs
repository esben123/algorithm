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
       // string testString ="";

        public void CreateGrid()
        {
            allNodes = new Node[(int)GameWorld.ShopDimensions.X, (int)GameWorld.ShopDimensions.Y];

            for (int y = 1; y < GameWorld.ShopDimensions.Y; y++)
            {
                for (int x = 1; x < GameWorld.ShopDimensions.X; x++)
                {
                    bool isFilled = GameWorld.ShopGo[x, y].Item == Item.Nothing;
                    allNodes[x,y] = new Node(new Point(x, y), isFilled);

         //           testString += isFilled.ToString();
           //         testString += " ";
                }
             //   testString += "\n";

            }

           // Console.WriteLine(testString);

        }

        public SmarterLinkedList<Node> GetNeighbours(Node node)
        {
            SmarterLinkedList<Node> neighbours = new SmarterLinkedList<Node>();

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0)        
                        continue;          

                    int checkX = node.GridPos.X + x;
                    int checkY = node.GridPos.Y + y;

                    if (checkX >= 0 && checkX < allNodes.GetLength(1) && checkY >= 0 && checkY < allNodes.GetLength(0)) //check for out of bounds
                    {
                        if (!allNodes[checkY, checkX].IsFilled)
                            neighbours.Add(allNodes[checkY, checkX]); 
                    }
                }
            }
            return neighbours;
        }
    }
}
