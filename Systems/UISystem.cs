using ECS.Components;
using ECS.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Systems
{
    public class UISystem : ECSSystem, DrawableSystem
    {
        public UISystem(ECSEntityManager entityManager) : base(entityManager)
        {
        }

        public override bool Accept(ECSComponent component)
        {
            return component is TextRenderer;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            TextRenderer textRenderer;
            Transform transform;
            for(int i = 0; i< GetComponents().Count; i++)
            {                
                if(GetComponents()[i] is TextRenderer)
                {
                    textRenderer = (TextRenderer) GetComponents()[i];
                    transform = textRenderer.Entity.GetComponent<Transform>();

                    spriteBatch.DrawString(textRenderer.Font, textRenderer.Text, transform.Position, textRenderer.Color);
                }
            }
        }
    }
}
