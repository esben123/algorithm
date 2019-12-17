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
    public class SpriteRenderer : Component
    {
        public Texture2D sprite;
        protected Vector2 origin;
        protected string spritename;
        private Vector2 renderOffset = Vector2.Zero;


        public SpriteRenderer(string spritename)
        {
            this.spritename = spritename;
        }

        public virtual Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Parent.Transform.Position.X - sprite.Width / 2, (int)Parent.Transform.Position.Y - sprite.Height / 2, sprite.Width, sprite.Height);
            }
        }

        public Vector2 RenderOffset { get => renderOffset; set => renderOffset = value; }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spritename);
            origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(sprite, Parent.Transform.Position + renderOffset, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
