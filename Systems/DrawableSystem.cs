using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Systems
{
    public interface DrawableSystem
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
