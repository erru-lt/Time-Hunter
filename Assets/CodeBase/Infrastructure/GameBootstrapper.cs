using Assets.CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private StatesFactory _statesFactory;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(StatesFactory statesFactory, IGameStateMachine gameStateMachine)
        {
            _statesFactory = statesFactory;
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<BootstrapState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadLevelState>());

            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
