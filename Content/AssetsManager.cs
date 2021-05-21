using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Content
{
    public class AssetsManager
    {
        public static AssetsManager Instance;

        private ContentManager content;

        public Texture2D PLAYER_SPRITE;

        public SpriteFont DEFAULT_FONT;

        public AssetsManager(ContentManager content)
        {
            Instance = this;
            this.content = content;

            PLAYER_SPRITE = content.Load<Texture2D>("player");
            DEFAULT_FONT = content.Load<SpriteFont>("StandardFont");
        }
    }
}
