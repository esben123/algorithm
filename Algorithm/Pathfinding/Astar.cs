using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Astar
    {

        public void FindPath(Node start, Node end)
        {
            SmarterLinkedList<Node> openList;
            SmarterLinkedList<Node> closedList;

        }

        public int GetManhattanDistance(Node a, Node b)
        {
            int x = Math.Abs(a.GridPos.X - b.GridPos.X);
            int y = Math.Abs(a.GridPos.Y - b.GridPos.Y);

            return x + y;
        }
    }
}
