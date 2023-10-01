using Assets.CodeBase.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Spawner
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private EnemyTypeId _enemyTypeId;
        private EnemyFactory _enemyFactory;

        [Inject]
        public void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void SpawnEnemy()
        {
            _enemyFactory.Create();
        }
    }
}
