using ECS.Entities;
using ECS.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Components
{
    public class PlayerMovementBehaviour : Behaviour
    {
        Transform transform;

        Vector2 velocity = Vector2.Zero;

        float speed = 50f;

        public override void Init()
        {
            transform = Entity.GetComponent<Transform>();
        }

        public override void Start()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            double dt = gameTime.ElapsedGameTime.TotalSeconds;
            float vx = 0;
            float vy = 0;
            
            if(keyboardState.IsKeyDown(Keys.Left))
            {
                vx = -1 * speed;
            }
            if(keyboardState.IsKeyDown(Keys.Right))
            {
                vx = 1 * speed;
            }

            if(keyboardState.IsKeyDown(Keys.Delete))
            {
                Destroy();
            }
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                SceneManager.Instance.SetScene(1);
            }

            velocity = new Vector2(vx * (float) dt, vy * (float) dt);

            transform.Position += velocity;
        }
    }
}
