using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Entities
{
    public class ECSEntityManager
    {
        public string InstanceID { get; set; } = Guid.NewGuid().ToString();

        private List<ECSEntity> entities = new List<ECSEntity>();

        public event Action<ECSEntity> OnEntityAdded;        
        public event Action<ECSEntity> OnEntityRemoved;
        public event Action<ECSEntity, ECSComponent> OnComponentAddedToEntity;
        public event Action<ECSEntity, ECSComponent> OnComponentRemovedToEntity;

        private int nextId = -1;
        public int NextId()
        {
            return nextId++;
        }

        public void AddEntity(ECSEntity entity)
        {
            if(!entities.Contains(entity))
            {
                entities.Add(entity);
                OnEntityAdded?.Invoke(entity);

                entity.OnComponentAdded += cmp =>
                {
                    OnComponentAddedToEntity?.Invoke(entity, cmp);
                };

                entity.OnComponentRemoved += cmp => OnComponentRemovedToEntity?.Invoke(entity, cmp);
            }
        }        

        public void RemoveEntity(ECSEntity entity)
        {
            bool removed = entities.Remove(entity);
            if(removed)
            {
                OnEntityRemoved?.Invoke(entity);
            }
        }
    }
}
