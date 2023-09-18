using Assets.CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private StatesFactory _statesFactory;
        private GameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(StatesFactory statesFactory, GameStateMachine gameStateMachine)
        {
            _statesFactory = statesFactory;
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<BootstrapState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());

            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
