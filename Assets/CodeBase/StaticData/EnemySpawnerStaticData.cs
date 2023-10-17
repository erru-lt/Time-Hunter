using Assets.CodeBase.GameLogic.Spawner;
using System;
using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    [Serializable]
    public class EnemySpawnerStaticData
    {
        public string Id;
        public EnemyTypeId EnemyTypeId;
        public Vector3 Position;

        public EnemySpawnerStaticData(string id, EnemyTypeId enemyTypeId, Vector3 position)
        {
            Id = id;
            EnemyTypeId = enemyTypeId;
            Position = position;
        }
    }
}
