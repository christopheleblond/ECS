using ECS.Entities;
using ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Scenes
{
    public class SceneManager
    {
        private static SceneManager _instance;

        public static SceneManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new SceneManager();
                }
                return _instance;
            }
        }

        private Dictionary<int, Scene> scenes = new Dictionary<int, Scene>();

        public int NextSceneId = 0;

        private Scene _currentScene;

        private int nextSceneId = 0;

        public void AddScene(Scene scene)
        {
            scene.Id = NextSceneId++;
            scene.world.RegisterSystem(new RenderingSystem(scene.world.EntityManager));
            scene.world.RegisterSystem(new BehaviourSystem(scene.world.EntityManager));
            scene.world.RegisterSystem(new UISystem(scene.world.EntityManager));

            scenes.Add(scene.Id, scene);
        }

        public void SetScene(int sceneId)
        {
            if(_currentScene == null)
            {
                _currentScene = scenes[sceneId];
            }
            this.nextSceneId = sceneId;
        }

        public void Update(GameTime gameTime)
        {
            if(_currentScene == null)
            {
                return;
            }

            if(nextSceneId != _currentScene.Id)
            {
                _currentScene.Finish();

                if(_currentScene.IsFinished)
                {
                    _currentScene = scenes[nextSceneId];
                }
            }

            if(!_currentScene.IsStarted)
            {                
                _currentScene.Start();
            }

            _currentScene.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(_currentScene != null)
            {
                _currentScene.Draw(spriteBatch);
            }
        }
    }
}
