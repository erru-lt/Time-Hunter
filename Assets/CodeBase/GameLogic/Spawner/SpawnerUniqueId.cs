using System;
using UnityEngine;

namespace Assets.CodeBase.GameLogic.Spawner
{
    public class SpawnerUniqueId : MonoBehaviour
    {
        public string Id;

        public void GenerateId()
        {
            Id = $"{gameObject.scene.name}_{Guid.NewGuid()}";
        }
    }
}
