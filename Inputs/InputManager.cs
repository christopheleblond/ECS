using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Inputs
{
    public class InputManager
    {
        private static InputManager _instance;

        public static InputManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new InputManager();
                }
                return _instance;
            }
        }

        private KeyboardState keyboardState;

        private KeyboardState previousState;

        public void Update(GameTime gameTime)
        {



            keyboardState = Keyboard.GetState();
        }

        public bool IsKeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && !previousState.IsKeyDown(key);
        }
    }
}
