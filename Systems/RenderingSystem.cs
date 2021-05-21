using ECS.Components;
using ECS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Systems
{
    class RenderingSystemComponent : ECSComponent
    {
        public Renderer Renderer { get; set; }

        public Transform Transform { get; set; }

        public RenderingSystemComponent(Renderer renderer, Transform transform)
        {
            this.Renderer = renderer;
            this.Transform = transform;
        }
    }

    public class RenderingSystem : ECSSystem, DrawableSystem
    {
        public RenderingSystem(ECSEntityManager entityManager) : base(entityManager)
        {
        }

        private RenderingSystemComponent FindComponent(Transform transform, Renderer renderer)
        {
           ECSComponent cmp = GetComponents().Find(c => ((RenderingSystemComponent)c).Renderer.Equals(renderer) && ((RenderingSystemComponent)c).Transform.Equals(transform));
            if(cmp != null)
            {
                return (RenderingSystemComponent)cmp;
            }
            else
            {
                return null;
            }
        }

        public override void OnComponentAddedToEntity(ECSEntity entity, ECSComponent component)
        {            
            if(component != null && component is Renderer)
            {
                AddComponent(new RenderingSystemComponent(component as Renderer, entity.GetComponent<Transform>()));
            }
        }


        public override void OnEntityRemoved(ECSEntity entity)
        {
            Transform transform = entity.GetComponent<Transform>();
            Renderer renderer = entity.GetComponent<Renderer>();

            RenderingSystemComponent renderingSystemComponent = FindComponent(transform, renderer);
            if(renderingSystemComponent != null)
            {
                RemoveComponent(renderingSystemComponent);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {                       
            foreach(RenderingSystemComponent component in GetComponents())
            {
                spriteBatch.Draw(component.Renderer.Texture, component.Transform.Position, component.Renderer.Color);
            }
        }

        public override bool Accept(ECSComponent component)
        {
            return false;
        }
    }
}
