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
        Vector2 fontsize;
        bool enableBg = false; //hack instead of making derived class


        public Color RenderColor { get => renderColor; set => renderColor = value; }

        public FontRenderer(string content, bool enableBg = false)
        {
            stringContent = content;
            this.enableBg = enableBg;
        }

        public override void LoadContent(ContentManager content)
        {
            if (enableBg)
                font = content.Load<SpriteFont>("font");
            else
                font = content.Load<SpriteFont>("smallFont");
            dummyTexture = content.Load<Texture2D>("1pxbg");
            fontsize = font.MeasureString(stringContent);
        }

        public void SetContent(string content, bool enableBg = false)
        {
            stringContent = content;
            fontsize = font.MeasureString(stringContent);
            this.enableBg = enableBg;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 tempOffset = new Vector2(-13, -15);

            if (enableBg)
            {
                tempOffset = new Vector2(-16, 16);
                dummyRectangle = new Rectangle(10, 10, (int)fontsize.X, (int)fontsize.Y);
                spriteBatch.Draw(dummyTexture, Parent.Transform.Position + tempOffset, dummyRectangle, Color.White);
            }         
            spriteBatch.DrawString(font, stringContent, Parent.Transform.Position + tempOffset, renderColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
