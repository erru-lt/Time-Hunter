using Assets.CodeBase.Services.StaticData;

namespace Assets.CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            InitializeServices();
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }

        private void InitializeServices()
        {
            _staticDataService.Load();
        }
    }
}
