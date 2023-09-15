using Assets.CodeBase.Services.Input;
using Zenject;

namespace Assets.CodeBase.Infrastructure.ZenjectInstallers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService() => 
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
    }
}
