using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Node
    {
       
        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost { get => HCost + GCost; }

        public Node Parent;

        public Point GridPos { get; private set; }
        public bool IsFilled { get; set; }

        public Node(Point gridPos, bool isFilled)
        {
            GridPos = gridPos;
            IsFilled = isFilled;
        }
    }
}
