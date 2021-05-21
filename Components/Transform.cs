using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Components
{
    public class Transform : ECSComponent
    {
        public Vector2 Position { get; set; } = Vector2.Zero;

        public Vector2 Rotation { get; set; } = Vector2.Zero;

        public Vector2 Scale { get; set; } = Vector2.Zero;

        public Transform(Vector2 position)
        {
            Position = position;
        }
    }
}
