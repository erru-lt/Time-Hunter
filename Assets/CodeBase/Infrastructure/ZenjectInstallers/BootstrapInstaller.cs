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
            //BindStatesFactory();
            //BindGameStateMachine();
            BindInputService();
        }

        private void BindStatesFactory() => 
            Container.Bind<StatesFactory>().AsSingle();

        private void BindGameStateMachine() => 
            Container.Bind<GameStateMachine>().AsSingle();

        private void BindInputService() => 
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
    }
}
