using UnityEngine;

namespace Assets.CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        public void Enter()
        {
            Debug.Log($"entered {GetType()} state");
        }

        public void Exit()
        {
            Debug.Log($"exited {GetType()} state");
        }
    }
}
