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
        public void FindPath(Node start, Node end)
        {
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            openList.Add(start);

            while(openList.Count > 0)
            {
                Node currentNode = openList[0];

                for (int i = 1; i < openList.Count; i++)
                {
                    if(openList[i].FCost < currentNode.FCost || openList[i].FCost == currentNode.FCost && openList[i].HCost < currentNode.HCost)
                    {
                        currentNode = openList[i];
                    }
                }
                openList.Remove(currentNode);
                closedList.Add(currentNode);
            }
            
        }

        public int GetManhattanDistance(Node a, Node b)
        {
            int x = Math.Abs(a.GridPos.X - b.GridPos.X);
            int y = Math.Abs(a.GridPos.Y - b.GridPos.Y);

            return x + y;
        }

        public int MoveCost(Node current, Node other)
        {
            if (GetManhattanDistance(current, other) == 20)
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
