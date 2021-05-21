using ECS.Entities;
using ECS.Prefabs;
using ECS.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Scenes
{
    public class GameOverScene : Scene
    {
        private ECSEntity gameOver;

        public override void OnLoad()
        {
            PrefabFactory prefabFactory = new PrefabFactory(world.EntityManager);

            gameOver = prefabFactory.CreateSpriteText("Game OVER!");
            gameOver.AddComponent(new GameOverBehaviour());
        }
    }
}
