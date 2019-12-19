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

        public Grid()
        {
            CreateGrid();
        }

       //  string testString ="";

        public void CreateGrid()
        {
            allNodes = new Node[(int)GameWorld.ShopDimensions.X, (int)GameWorld.ShopDimensions.Y];

            for (int y = 1; y < GameWorld.ShopDimensions.Y; y++)
            {
                for (int x = 1; x < GameWorld.ShopDimensions.X; x++)
                {
                    bool isFilled = GameWorld.ShopGo[x, y].Item != Item.Nothing;
                    allNodes[x,y] = new Node(new Point(x, y), isFilled);

                  //  testString += isFilled.ToString();
                //    testString += " ";
                }
              //  testString += "\n";
            }
           // Console.WriteLine(testString);
        }

        public Node FindnodeAtGridpos(Point gridPos)
        {
            return allNodes[gridPos.X, gridPos.Y];
        }

        public Node FindNodeByItemType(Item item)
        {
            GameObject temp = new GameObject(); ;

            for (int y = 1; y < GameWorld.ShopDimensions.Y; y++)
            {
                for (int x = 1; x < GameWorld.ShopDimensions.X; x++)
                {
                    temp = GameWorld.ShopGo[x, y];
                    if (temp.Item == item)
                        return FindnodeAtGridpos(temp.Transform.GridPos);
                }
            }
                return null;
        }

        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0)        
                        continue;          

                    int checkX = node.GridPos.X + x;
                    int checkY = node.GridPos.Y + y;

                    if (checkX >= 1 && checkX < allNodes.GetLength(0)  && checkY >= 1 && checkY < allNodes.GetLength(1) ) //check for out of bounds
                    {
                        if (!allNodes[checkX, checkY].IsFilled)
                            neighbours.Add(allNodes[checkX, checkY]); 
                    }
                }
            }
            return neighbours;
        }
    }
}
