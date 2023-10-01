using Assets.CodeBase.Infrastructure.AssetManagement;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.States;
using Assets.CodeBase.Services.Input;
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
            BindEnemyFactory();
        }

        private void BindAssetProvider() => 
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindStatesFactory() => 
            Container.Bind<StatesFactory>().AsSingle();

        private void BindGameStateMachine() => 
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();

        private void BindInputService() => 
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();

        private void BindEnemyFactory() => 
            Container.Bind<EnemyFactory>().AsSingle();
    }
}
