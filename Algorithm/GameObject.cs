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
    public class GameObject
    {
        private List<Component> components = new List<Component>();
        private SpriteRenderer spriteRenderer;
        private FontRenderer fontRenderer;
        private Transform transform;
        private ShoppingList shoppingList;

        private Item item = Item.Nothing;

        public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
        public Transform Transform { get => transform; set => transform = value; }
        public ShoppingList ShoppingList { get => shoppingList; set => shoppingList = value; }
        public FontRenderer FontRenderer { get => fontRenderer; set => fontRenderer = value; }
        public Item Item { get => item; set => item = value; }

        public void AddComponent(Component component)
        {
            component.Attach(this);
            components.Add(component);

            if (component is Transform)
                transform = (Transform)component;

            else if (component is SpriteRenderer)
                spriteRenderer = (SpriteRenderer)component;

            else if (component is FontRenderer)
                fontRenderer = (FontRenderer)component;
        }

        public virtual void LoadContent(ContentManager content)
        {
            foreach (Component comp in components)
            {
                comp.LoadContent(content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Component comp in components)
            {
                comp.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component comp in components)
            {
                comp.Draw(spriteBatch);
            }
        }
    }
}

