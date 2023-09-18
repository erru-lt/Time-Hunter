using Zenject;

namespace Assets.CodeBase.Infrastructure.States
{
    public class StatesFactory
    {
        private readonly IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public TState Create<TState>() where TState : IState =>
            _instantiator.Instantiate<TState>();
    }
}