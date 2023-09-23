using System;
using System.Collections.Generic;

namespace Assets.CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private IState _activeState;
        private readonly Dictionary<Type, IState> _states;

        public GameStateMachine() =>
            _states = new Dictionary<Type, IState>();

        public void RegisterState<TState>(TState state) where TState : class, IState =>
            _states.Add(typeof(TState), state);

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;
    }
}
