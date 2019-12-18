using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Astar
    {
        public List<Node> path;

        public void FindPath(Node start, Node end, Grid snapshotGrid)
        {
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            openList.Add(start);
            Node currentNode = start;   //slide 1

            while (openList.Count > 0)                      //slide 7
            {
                foreach (Node openNode in openList)         //slide 7
                    if (openNode.FCost < currentNode.FCost) //slide 7
                        currentNode = openNode;             //slide 7

                List<Node> neighbouringNodes = snapshotGrid.GetNeighbours(currentNode); //slide 2 
                foreach (Node nNode in neighbouringNodes)   //slide 9.2
                    if (!openList.Contains(nNode))          //slide 9.2
                        openList.Add(nNode);                //slide 9.2

                closedList.Add(currentNode);    //slide 5 + 8


                foreach (Node n in neighbouringNodes)       //slide 3
                {
                     int score = currentNode.GCost + GetHcost(n, end);

                    n.Parent = currentNode;     //slide 4 - 9.3

                    n.GCost = currentNode.GCost + MoveCost(currentNode, n);     //slide 6
                    n.HCost = GetHcost(n, end);                                 //slide 6

                    if (!openList.Contains(n))              //slide 3
                        openList.Add(n);                    //slide 3
                    else if ()                  //slide 9.4

                }
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

        private void FinalPath(Node startingPoint, Node endPoint)
        {
            List<Node> finalPath = new List<Node>();
            Node current = endPoint;

            while(current !=null && current.GridPos != startingPoint.GridPos)
            {
                finalPath.Add(current);
                current = current.Parent;
            }

            if(finalPath.Count > 0)
            {
                path = finalPath;
            }
        }
    }
}
