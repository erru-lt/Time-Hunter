namespace Assets.CodeBase.Infrastructure.States
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void RegisterState<TState>(TState state) where TState : class, IState;
    }
}