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
            }

            obj.LoadContent(GameWorld.Instance.Content);
            GameWorld.Instance.AddGameObject(obj);
        }
    }
}
