using Assets.CodeBase.Hero;
using Assets.CodeBase.Infrastructure.AssetManagement;
using System;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public class HeroFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _diContainer;

        public HeroFactory(IAssetProvider assetProvider, DiContainer diContainer)
        {
            _assetProvider = assetProvider;
            _diContainer = diContainer;
        }

        public void CreateHero()
        {
            GameObject heroPrefab = LoadPrefab();
            _diContainer.InstantiatePrefabForComponent<HeroMove>(heroPrefab);
        }

        private GameObject LoadPrefab() =>
            _assetProvider.LoadPrefab(AssetPath.HeroPath);
    }
}
