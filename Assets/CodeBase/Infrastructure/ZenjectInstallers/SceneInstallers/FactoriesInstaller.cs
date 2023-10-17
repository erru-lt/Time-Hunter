using Assets.CodeBase.GameLogic.Spawner;
using Assets.CodeBase.Hero;
using System;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure.ZenjectInstallers.SceneInstallers
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _enemySpawnPoint;
        [SerializeField] private GameObject _hero;
        [SerializeField] private GameObject _enemy;

        public override void InstallBindings()
        {
            Container.Bind<HeroMove>().FromComponentInNewPrefab(_hero);
            
            Container.BindFactory<EnemyAttack, EnemyAttack.Factory>().FromComponentInNewPrefab(_enemy);
            Container.BindFactory<EnemySpawnPoint, EnemySpawnPoint.Factory>().FromComponentInNewPrefab(_enemySpawnPoint);
            Container.BindFactory<HeroMove, HeroMove.Factory>().FromComponentInNewPrefab(_hero);
        }
    }
}
