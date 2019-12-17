using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Algorithm
{
    class TileFactory : Factory
    {
        private static TileFactory instance;
        public static TileFactory Instance        
        {

            get
            {
                if (instance == null)
                    instance = new TileFactory();

                return instance;
            }
            set => instance = value;
        }

        public override void create(String name, Point gridPos)
        {

            GameObject obj = new GameObject();
            Transform tx = new Transform(gridPos);
            SpriteRenderer spr = new SpriteRenderer(name);
            obj.AddComponent(tx);
            obj.AddComponent(spr);

            switch (name)
            {
                case "floor":                
                break;
                case "torso":
                    obj.Item = Item.Armour;
                    Shop.ItemsForSale.Add(obj);
                break;
                case "spear":
                    obj.Item = Item.Spear;
                    Shop.ItemsForSale.Add(obj);
                    break;
                case "helmets":
                    obj.Item = Item.Helmet;
                    Shop.ItemsForSale.Add(obj);
                    break;
                case "book_big":
                    obj.Item = Item.CallOfCthulhu;
                    Shop.ItemsForSale.Add(obj);
                    break;
                case "book_small":
                    obj.Item = Item.Necronomicon;
                    Shop.ItemsForSale.Add(obj);
                    break;
            }

            obj.LoadContent(GameWorld.Instance.Content);
            GameWorld.Instance.AddGameObject(obj);
        }
    }
}
