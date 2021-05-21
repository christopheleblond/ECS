using ECS.Components;
using ECS.Entities;
using ECS.Prefabs;
using ECS.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Scenes
{
    public class UserScene : Scene
    {
        private ECSEntity player;

        public UserScene()
        {
        }

        public override void OnLoad()
        {
            PrefabFactory prefabFactory = new PrefabFactory(world.EntityManager);
            player = prefabFactory.Create(PrefabIds.PLAYER);
            player.GetComponent<Transform>().Position = new Vector2(250, 50);
        }
    }
}
