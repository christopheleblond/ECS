using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Components
{
    public class Renderer : ECSComponent
    {
        public Texture2D Texture { get; set; }

        public Color Color { get; set; }

        public Renderer(Texture2D texture, Color color)
        {
            this.Texture = texture;
            this.Color = color;
        }
    }
}
