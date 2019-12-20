using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Astar
    {
        //   public List<Node> path;
        bool ShowDebugStats = true;


        public void FindPath(Node start, Node end, Grid snapshotGrid)
        {
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();


            openList.Add(start);        //slide 1
            Node currentNode = start;   //slide 1

            while (openList.Count > 0)                      //slide 7 --- slide 10
            {
                currentNode = openList[0];
                foreach (Node openNode in openList)         //slide 7
                    if (openNode.FCost < currentNode.FCost) //slide 7
                        currentNode = openNode;             //slide 7


                if (GetHcost(currentNode, end) < 20)         //slide 10  (path found) //hacked to 1 square from goal
                {
                    GetFinalPath(start, currentNode);           //slide 10
                    break;
                }

                SmarterLinkedList<Node> neighbouringNodes = snapshotGrid.GetNeighbours(currentNode); //slide 2 

                closedList.Add(currentNode);    //slide 5 + 8
                openList.Remove(currentNode);

                foreach (Node n in neighbouringNodes)       //slide 3 + 9
                {
                     int tempGCost = currentNode.GCost + MoveCost(currentNode, n);      //gcost indtil videre + gcost fra current node til neighbour (9.4)
                    if (!openList.Contains(n) && !closedList.Contains(n))              //slide 3 + 9.2
                    {
                        openList.Add(n);                    //slide 3 + 9.2


                        if (n.GCost== 0 || n.GCost > 0 && tempGCost < n.GCost) //slide 9.4 eller 9.5?
                        {
                            n.GCost = tempGCost;                                        //slide 6
                            n.HCost = GetHcost(n, end);                                 //slide 6
                            n.Parent = currentNode;     //slide 4 - 9.3
                        }
                    }
                       

                    if (ShowDebugStats)       //DEBUG
                    {
                        string gCost = $"{n.GCost}";
                        string hCost = $"{n.HCost}";
                        string FCost = $"{n.FCost}";

                        GameObject floor = GameWorld.ShopGo[n.GridPos.X, n.GridPos.Y];
                        floor.FontRenderer.SetContent(@"g: " + gCost + "\nh: " + hCost + "\nf: " + FCost);
                    }
                }
               // break;
              
            }
        }

        public int GetHcost(Node a, Node b) //ManhattanDistance
        {
            int x = Math.Abs(a.GridPos.X - b.GridPos.X);
            int y = Math.Abs(a.GridPos.Y - b.GridPos.Y);

            return (x + y) * 10;
        }

        public int MoveCost(Node current, Node other)
        {
            if (GetHcost(current, other) == 20)
                return 14;

            else
                return 10;
        }

        private void GetFinalPath(Node startNode, Node endNode)
        {
            List<Node> finalPath = new List<Node>();
            Node current = endNode;

            while(current !=null && current.GridPos != startNode.GridPos)       //slide 10.2
            {
                finalPath.Add(current);

                if (ShowDebugStats)
                {
                    GameObject floor = GameWorld.ShopGo[current.GridPos.X, current.GridPos.Y];
                    floor.FontRenderer.RenderColor = Color.Green;
                }                                                       
                current = current.Parent;                                       //slide 10.2
            }

            if(finalPath.Count > 0)
            {
                finalPath.Reverse();
            }
        }
    }
}
