using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Algorithm
{
    public class ShopperFactory : Factory
    {
        private static ShopperFactory instance;
        public static ShopperFactory Instance
        {
            get {
                if (instance == null)
                    instance = new ShopperFactory();

                return instance;
            }
           
        }

        public override void create(string name, Point gridPos)
        {
            GameObject obj = new GameObject();
            Transform tx = new Transform(gridPos);
            SpriteRenderer spr = new SpriteRenderer(name);
            ShoppingList sl = new ShoppingList();
            FontRenderer fr = new FontRenderer(sl.GetList());
            ShopperAi sai = new ShopperAi();

            obj.AddComponent(tx);
            obj.AddComponent(spr);
            obj.AddComponent(sl);
            obj.AddComponent(fr);
            obj.AddComponent(sai);

            switch (name)
            {
                case "shopper":
                    break;
            }

            obj.LoadContent(GameWorld.Instance.Content);
            GameWorld.Instance.AddGameObject(obj);
        }
    }
}
