using Assets.CodeBase.Hero;
using UnityEngine;
using Zenject;

public class HeroInstaller : MonoInstaller
{
    [SerializeField] private HeroMove _heroMove;

    public override void InstallBindings()
    {
        Container.Bind<HeroMove>().FromInstance(_heroMove).AsSingle();
    }
}
