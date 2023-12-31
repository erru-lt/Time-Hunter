using Assets.CodeBase.GameLogic.Spawner;
using Assets.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class EnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _diContainer;

        public EnemyFactory(IAssetProvider assetProvider, DiContainer diContainer)
        {
            _assetProvider = assetProvider;
            _diContainer = diContainer;
        }

        public void CreateEnemy(Transform parent)
        {
            GameObject enemyPrefab = LoadPrefab();
            _diContainer.InstantiatePrefabForComponent<EnemyAttack>(enemyPrefab, parent);
        }

        private GameObject LoadPrefab() =>
            _assetProvider.LoadPrefab(AssetPath.EnemyPath);
    }
}