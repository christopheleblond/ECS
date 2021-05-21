using ECS.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Components
{
    public class TextRenderer : ECSComponent
    {
        public string Text { get; set; } = "Enter your text";

        public Color Color { get; set; } = Color.White;

        public SpriteFont Font { get; set; } = AssetsManager.Instance.DEFAULT_FONT;

        public TextRenderer(string text, Color color)
        {
            this.Text = text;
            this.Color = color;
        }
    }
}
