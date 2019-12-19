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

        public void FindPath(Node start, Node end, Grid snapshotGrid)
        {
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            bool ShowDebugStats = true;

            openList.Add(start);        //slide 1
            Node currentNode = start;   //slide 1

            while (openList.Count > 0)                      //slide 7 --- slide 10
            {
                foreach (Node openNode in openList)         //slide 7
                    if (openNode.FCost < currentNode.FCost) //slide 7
                        currentNode = openNode;             //slide 7

                Console.WriteLine(openList.Count);

                List<Node> neighbouringNodes = snapshotGrid.GetNeighbours(currentNode); //slide 2 

                closedList.Add(currentNode);    //slide 5 + 8


                if (currentNode.GridPos == end.GridPos)         //slide 10  (path found)
                {
                    GetFinalPath(start, currentNode);           //slide 10
                    break;
                }

                foreach (Node n in neighbouringNodes)       //slide 3 + 9
                {
                     int tempGCost = currentNode.GCost + MoveCost(currentNode, n);      //gcost indtil videre + gcost fra current node til neighbour (9.4)
                    Console.WriteLine("temp" +tempGCost);
                    if (!openList.Contains(n))              //slide 3 + 9.2
                        openList.Add(n);                    //slide 3 + 9.2

                    if (tempGCost > n.GCost) //slide 9.4 eller 9.5?
                    { 
                    }
                    else
                    {
                        n.GCost = tempGCost;                                        //slide 6
                        n.HCost = GetHcost(n, end);                                 //slide 6
                        n.Parent = currentNode;     //slide 4 - 9.3
                    }

                    if (ShowDebugStats)       //DEBUG
                    {
                        string gCost = $"{n.GCost}";
                        string hCost = $"{n.HCost}";
                        string FCost = $"{n.FCost}";

                        GameObject floor = GameWorld.ShopGo[n.GridPos.X, n.GridPos.Y];
                        floor.FontRenderer.SetContent(@"g: " + gCost + "\nh: " + hCost + "\nf: " + FCost);
                        Console.WriteLine(gCost);
                    }
                }
                break;
              
            }
        }

        public int GetHcost(Node a, Node b) //ManhattanDistance
        {
            int x = Math.Abs(a.GridPos.X - b.GridPos.X);
            int y = Math.Abs(a.GridPos.Y - b.GridPos.Y);

            return x + y;
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

            while(current !=null && current.GridPos != startNode.GridPos)
            {
                finalPath.Add(current);                                         //slide 10.2
                current = current.Parent;                                       //slide 10.2
            }

            if(finalPath.Count > 0)
            {
                finalPath.Reverse();
            }
        }
    }
}
