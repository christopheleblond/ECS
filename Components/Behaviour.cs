using ECS.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Components
{
    public abstract class Behaviour : ECSComponent
    {        
        public abstract void Start();

        public abstract void Update(GameTime gameTime);

        public void Destroy()
        {
            Entity.Destroy();
        }
    }
}
