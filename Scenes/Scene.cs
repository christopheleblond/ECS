using ECS.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Scenes
{
    public enum SceneStates
    {
        NOT_STARTED,
        STARTING,
        RUNNING,
        FINISHING,
        FINISHED
    }

    public abstract class Scene
    {
        public int Id { get; set; }

        public SceneStates State { get; set; } = SceneStates.NOT_STARTED;
        public bool IsFinished { get { return State == SceneStates.FINISHED; } }
        public bool IsStarted { get { return State == SceneStates.RUNNING || State == SceneStates.STARTING; } }

        public bool Loaded { get; set; } = false;

        public ECSEngine world = new ECSEngine();

        internal void LoadContent()
        {
            OnLoad();

            Loaded = true;
        }

        public void Update(GameTime gameTime)
        {
            world.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            world.Draw(spriteBatch);
        }

        internal void Finish()
        {
            OnFinish();

            State = SceneStates.FINISHED;
        }

        internal void Start()
        {
            if(!Loaded)
            {
                LoadContent();
            }

            OnStart();

            State = SceneStates.RUNNING;
        }

        public virtual void OnStart()
        {

        }

        public virtual void OnFinish()
        {

        }

        public virtual void OnLoad()
        {

        }
    }
}
