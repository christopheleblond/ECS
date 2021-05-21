using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Systems
{
    public interface UpdatableSystem
    {
        void Update(GameTime gameTime);
    }
}
