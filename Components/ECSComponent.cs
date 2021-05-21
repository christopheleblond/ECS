using ECS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS
{
    public abstract class ECSComponent
    {
        public ECSEntity Entity { get; set; }

        public int EntityId
        {
            get { return Entity.GetId();  }           
        }

        public virtual void Init()
        {

        }
    }
}
