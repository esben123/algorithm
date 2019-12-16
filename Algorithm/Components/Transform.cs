using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class Transform : Component
    {
        Vector2 position;
        Point gridPos;
        private int tileSize = 32;

        

        public Vector2 Position
        {
            get
            {
                {
                    return position;
                }
            }
            set
            {
                {
                    position = value;
                    gridPos = new Point((int)position.X / tileSize, (int)position.Y / tileSize);
                }
            }
        }
        public Point GridPos
        {
            get
            {
                {
                    return gridPos;
                }
            }
            set
            {
                {
                    gridPos = value;
                    position = new Vector2((tileSize / 2) + gridPos.X * tileSize, (tileSize / 2) + gridPos.Y * tileSize);
                }
            }
        }

        public Transform(Point gridPos)
        {
            GridPos = gridPos;
        }
        public void Translate(Vector2 translation)
        {

        }
    }
}
