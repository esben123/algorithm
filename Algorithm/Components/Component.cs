using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public abstract class Component
    {
        private GameObject parent;

        public GameObject Parent { get => parent; private set => parent = value; }

        public virtual void Attach(GameObject go)
        {
            parent = go;
        }

        public virtual void LoadContent(ContentManager content)
        {
        }
        public virtual void Update(GameTime gametime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
