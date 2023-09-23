using Assets.CodeBase.Infrastructure.States;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;        
        }

        public void Enter()
        {
            Debug.Log($"entered {GetType()} state");
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
            Debug.Log($"exited {GetType()} state");
        }
    }
}
