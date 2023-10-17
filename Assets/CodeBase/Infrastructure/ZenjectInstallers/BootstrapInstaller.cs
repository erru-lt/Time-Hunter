using Assets.CodeBase.GameLogic.Spawner;
using Assets.CodeBase.Hero;
using Assets.CodeBase.Infrastructure.AssetManagement;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.States;
using Assets.CodeBase.Services.Input;
using Assets.CodeBase.Services.StaticData;
using System;
using Zenject;

namespace Assets.CodeBase.Infrastructure.ZenjectInstallers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAssetProvider();
            BindStatesFactory();
            BindGameStateMachine();
            BindInputService();
            BindHeroFactory();
            BindEnemyFactory();
            BindSpawnerFactory();
            BindStaticDataService();
            //BindFactories();
        }

        private void BindAssetProvider() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindStatesFactory() =>
            Container.Bind<StatesFactory>().AsSingle();

        private void BindGameStateMachine() =>
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

        private void BindInputService() =>
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();

        private void BindHeroFactory() =>
            Container.Bind<HeroFactory>().AsSingle();

        private void BindEnemyFactory() =>
            Container.Bind<EnemyFactory>().AsSingle();

        private void BindSpawnerFactory() =>
            Container.Bind<SpawnerFactory>().AsSingle();

        private void BindStaticDataService() =>
             Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();

        private void BindFactories()
        {
            Container.BindFactory<HeroMove, HeroMove.Factory>().AsSingle();
            Container.BindFactory<EnemySpawnPoint, EnemySpawnPoint.Factory>().AsSingle();
            Container.BindFactory<EnemyAttack, EnemyAttack.Factory>().AsSingle();
        }
    }
}
