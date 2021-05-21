using ECS.Components;
using ECS.Content;
using ECS.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Prefabs
{
    public enum PrefabIds
    {
        PLAYER,
        BOSS
    }

    public class PrefabFactory
    {
        private ECSEntityManager entityManager;

        public PrefabFactory(ECSEntityManager entityManager)
        {
            this.entityManager = entityManager;
        }


        public ECSEntity Create(PrefabIds prefabId)
        {
            switch(prefabId)
            {
                case PrefabIds.PLAYER: return CreatePlayer();
                default:
                    return null;
            }
        }

        private ECSEntity CreatePlayer()
        {
            return new ECSEntity(entityManager)
                .AddComponent(new Transform(new Vector2(10, 10)))
                .AddComponent(new Renderer(AssetsManager.Instance.PLAYER_SPRITE, Color.White))
                .AddComponent(new PlayerMovementBehaviour());
        }

        public ECSEntity CreateSpriteText(string text)
        {
            return new ECSEntity(entityManager)
                .AddComponent(new Transform(new Vector2(10, 10)))
                .AddComponent(new TextRenderer("Game Over", Color.White));
        }
    }
}
