﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Algorithm
{
    class ShopFactory : Factory
    {
        private static ShopFactory instance;
        public static ShopFactory Instance        
        {
            get
            {
                if (instance == null)
                    instance = new ShopFactory();

                return instance;
            }
        }

        public override void create(String name, Point gridPos)
        {

            GameObject obj = new GameObject();
            Transform tx = new Transform(gridPos);
            SpriteRenderer spr = new SpriteRenderer(name);
            obj.AddComponent(tx);
            obj.AddComponent(spr);
            FontRenderer fr = new FontRenderer(""); //move to case
            obj.AddComponent(fr);

            switch (name)
            {
                case "floor":
                 
                    break;
                case "torso":
                    obj.Item = Item.Armour;
                    spr.RenderOffset = new Vector2(0, -6);
                    break;
                case "spear":
                    obj.Item = Item.Spear;
                    spr.RenderOffset = new Vector2(0, -22);

                    break;
                case "helmets":
                    obj.Item = Item.Helmet;
                    spr.RenderOffset = new Vector2(0, -6);
                    break;
                case "book_big":
                    obj.Item = Item.CallOfCthulhu;
                    spr.RenderOffset = new Vector2(0, -21);
                    break;
                case "book_small":
                    obj.Item = Item.Necronomicon;
                    spr.RenderOffset = new Vector2(0, -10);
                    break;
                case "wall":
                    obj.Item = Item.Wall;
                    spr.RenderOffset = new Vector2(0, -13);
                    break;
                case "register":
                    obj.Item = Item.Register;
                    spr.RenderOffset = new Vector2(0, -13);
                    break;
            }

            GameWorld.ShopGo[gridPos.X, gridPos.Y] = obj;
            obj.LoadContent(GameWorld.Instance.Content);
            GameWorld.Instance.AddGameObject(obj);
        }
    }
}
