using ECS.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Systems
{
    public abstract class ECSSystem
    {
        private List<ECSComponent> components = new List<ECSComponent>();

        private ECSEntityManager entityManager;

        public ECSSystem(ECSEntityManager entityManager)
        {
            this.entityManager = entityManager;

            this.entityManager.OnEntityAdded += OnEntityAdded;
            this.entityManager.OnEntityRemoved += OnEntityRemoved;
            this.entityManager.OnComponentAddedToEntity += OnComponentAddedToEntity;
            this.entityManager.OnComponentRemovedToEntity += OnComponentRemovedFromEntity;
        }

        public List<ECSComponent> GetComponents()
        {
            return components;
        }

        public T GetComponent<T>() where T: ECSComponent
        {
            var component = components.Find(c => c.GetType() == typeof(T));
            if(component != null)
            {
                return (T) component;
            }
            else
            {
                return default(T);
            }
        }

        public abstract bool Accept(ECSComponent component);

        public void AddComponent(ECSComponent component)
        {
            components.Add(component);
        }

        public void RemoveComponent(ECSComponent component)
        {
            components.Remove(component);
        }

        public virtual void OnEntityAdded(ECSEntity entity)
        {
            foreach(ECSComponent cmp in entity.GetComponents())
            {
                if(Accept(cmp))
                {
                    AddComponent(cmp);
                }
            }
        }

        public virtual void OnEntityRemoved(ECSEntity entity)
        {
            foreach (ECSComponent cmp in entity.GetComponents())
            {
                if (Accept(cmp))
                {
                    RemoveComponent(cmp);
                }
            }
        }

        public virtual void OnComponentAddedToEntity(ECSEntity entity, ECSComponent component)
        {
            if(Accept(component))
            {
                AddComponent(component);
            }
        }

        public virtual void OnComponentRemovedFromEntity(ECSEntity entity, ECSComponent component)
        {
            if(Accept(component))
            {
                RemoveComponent(component);
            }
        }
    }
}
