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
    public class FontRenderer : Component
    {
        string stringContent = "";
        private SpriteFont font;

        private Color renderColor = Color.Yellow;

        public Color RenderColor { get => renderColor; set => renderColor = value; }

        public FontRenderer(string content)
        {
            stringContent = content;
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
        }

        public void SetContent(string content)
        {
            stringContent = content;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 tempOffset = new Vector2(-16, -16);
            spriteBatch.DrawString(font, stringContent, Parent.Transform.Position + tempOffset, renderColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
