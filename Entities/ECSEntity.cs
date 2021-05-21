using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Entities
{
    public class ECSEntity
    {
        private int id = 0;

        private List<ECSComponent> components = new List<ECSComponent>();

        private ECSEntityManager entityManager;

        public event Action<ECSComponent> OnComponentAdded;
        public event Action<ECSComponent> OnComponentRemoved;

        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public bool IsVisible { get; set; } = true;

        public ECSEntity(ECSEntityManager entityManager)
        {
            this.entityManager = entityManager;

            id = entityManager.NextId();

            entityManager.AddEntity(this);
        }

        public int GetId()
        {
            return id;
        }

        public T GetComponent<T>() where T: ECSComponent
        {
            ECSComponent component = components.Find(c => c.GetType() == typeof(T));

            if(component != null)
            {
                return (T)component;
            }
            else
            {
                return default(T);
            }
        }

        public List<ECSComponent> GetComponents() {
            return components;
        }

        public ECSEntity AddComponent(ECSComponent component)
        {
            if(!components.Contains(component))
            {
                components.Add(component);
                
                component.Entity = this;

                component.Init();

                OnComponentAdded?.Invoke(component);
            }
            return this;
        }

        public void RemoveComponent(ECSComponent component)
        {
            bool removed = components.Remove(component);           
            if(removed)
            {
                OnComponentRemoved?.Invoke(component);
            }
        }

        public void Destroy()
        {
            entityManager.RemoveEntity(this);
        }
    }
}
