using ECS.Components;
using ECS.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Systems
{
    public class BehaviourSystem : ECSSystem, UpdatableSystem
    {                     
        public BehaviourSystem(ECSEntityManager entityManager): base(entityManager)
        {
        }

        public void Update(GameTime gameTime)
        {              
            for(int i = 0; i < GetComponents().Count; i++)
            {
                ((Behaviour) GetComponents()[i]).Update(gameTime);
            }
        }

        public override bool Accept(ECSComponent component)
        {
            return component is Behaviour;
        }
    }
}
