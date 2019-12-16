using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public abstract class Factory
    {
        public abstract void create(string name, Point gridPos);

    }
}
