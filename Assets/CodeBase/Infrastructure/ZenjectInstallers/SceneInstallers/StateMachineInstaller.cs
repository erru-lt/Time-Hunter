using Assets.CodeBase.Infrastructure.States;
using Zenject;

namespace Assets.CodeBase.Infrastructure.ZenjectInstallers.SceneInstallers
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStatesFactory();
            BindGameStateMachine();
        }

        private void BindStatesFactory() =>
           Container.Bind<StatesFactory>().AsSingle();

        private void BindGameStateMachine() =>
            Container.Bind<GameStateMachine>().AsSingle();
    }
}
