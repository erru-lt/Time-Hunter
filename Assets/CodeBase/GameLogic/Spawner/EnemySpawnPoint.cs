using Assets.CodeBase.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.GameLogic.Spawner
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public EnemyTypeId EnemyTypeId;
        public string Id
        {
            get => _id;
            set => _id = value;
        }
        private string _id;
        
        private EnemyAttack.Factory _enemyFactory;

        [Inject]
        private void Construct(EnemyAttack.Factory enemyFactory)
        {
            Debug.Log("inject me");
            _enemyFactory = enemyFactory;
        }

        //private void Start()
        //{
        //    SpawnEnemy();
        //}

        public void SpawnEnemy()
        {
            if(_enemyFactory == null)
            {
                Debug.Log("enemy factory null");
                return;
            }
            _enemyFactory.Create();
        }

        public class Factory : PlaceholderFactory<EnemySpawnPoint>
        {

        }
    }
}
