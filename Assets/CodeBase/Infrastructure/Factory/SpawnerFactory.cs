using Assets.CodeBase.GameLogic.Spawner;
using Assets.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class SpawnerFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _diContainer;

        public SpawnerFactory(IAssetProvider assetProvider, DiContainer diContainer)
        {
            _assetProvider = assetProvider;
            _diContainer = diContainer;
        }

        public EnemySpawnPoint CreateEnemySpawner(string id, EnemyTypeId enemyTypeId, Vector3 position)
        {
            GameObject enemySpawnPointPrefab = LoadPrefab();

            EnemySpawnPoint enemySpawnPoint = _diContainer.InstantiatePrefabForComponent<EnemySpawnPoint>(enemySpawnPointPrefab);

            enemySpawnPoint.Id = id;
            enemySpawnPoint.EnemyTypeId = enemyTypeId;
            enemySpawnPoint.transform.position = position;

            return enemySpawnPoint;
        }

        private GameObject LoadPrefab() =>
            _assetProvider.LoadPrefab(AssetPath.EnemySpawnPointPath);
    }
}
