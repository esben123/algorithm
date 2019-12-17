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

        private Color renderColor = Color.Black;
        Texture2D dummyTexture;
        Rectangle dummyRectangle;
        Vector2 fontWidth;

        public Color RenderColor { get => renderColor; set => renderColor = value; }

        public FontRenderer(string content)
        {
            stringContent = content;
        }

        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("font");
            dummyTexture = content.Load<Texture2D>("1pxbg");
            fontWidth = font.MeasureString(stringContent);
        }

        public void SetContent(string content)
        {
            stringContent = content;
            fontWidth = font.MeasureString(stringContent);
        }

        public override void Draw(SpriteBatch spriteBatch)
        { 

            
            Vector2 tempOffset = new Vector2(-16, 16);
            dummyRectangle = new Rectangle(10,10 , (int)fontWidth.X, (int)fontWidth.Y);

            spriteBatch.Draw(dummyTexture, Parent.Transform.Position + tempOffset, dummyRectangle, Color.White);

            spriteBatch.DrawString(font, stringContent, Parent.Transform.Position + tempOffset, renderColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
