using Assets.CodeBase.GameLogic.BombLogic;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure.ZenjectInstallers.SceneInstallers
{
    public class BombInstaller : MonoInstaller
    {
        [SerializeField] private Bomb _bomb;

        public override void InstallBindings()
        {
            Container.Bind<Bomb>().FromInstance(_bomb).AsSingle();
        }
    }
}
