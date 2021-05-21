using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ECS.Systems;
using ECS.Entities;

namespace ECS.Engine
{
    public class ECSEngine
    {
        private List<DrawableSystem> drawableSystems;

        private List<UpdatableSystem> updatableSystems;

        public ECSEntityManager EntityManager { get; }

        public ECSEngine()
        {            
            drawableSystems = new List<DrawableSystem>();
            updatableSystems = new List<UpdatableSystem>();

            EntityManager = new ECSEntityManager();
        }

        public void RegisterSystem(ECSSystem system)
        {
            if(system != null)
            {
                if(system is DrawableSystem)
                {
                    drawableSystems.Add((DrawableSystem) system);
                }
                if(system is UpdatableSystem)
                {
                    updatableSystems.Add((UpdatableSystem) system);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(UpdatableSystem system in updatableSystems)
            {
                system.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (DrawableSystem system in drawableSystems)
            {
                system.Draw(spriteBatch);
            }
        }
    }
}
