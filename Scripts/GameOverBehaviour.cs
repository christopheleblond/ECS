using ECS.Components;
using ECS.Inputs;
using ECS.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Scripts
{
    public class GameOverBehaviour : Behaviour
    {
        public override void Start()
        {            
        }

        public override void Update(GameTime gameTime)
        {
            if(InputManager.Instance.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Back))
            {
                SceneManager.Instance.SetScene(0);
            }
        }
    }
}
