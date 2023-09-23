using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string HorizontalAxis = "Horizontal";
        protected const string VerticalAxis = "Vertical";
        private const string DashButton = "Space";

        public abstract Vector2 Axis { get; }

        public bool GetDashButton() =>
            SimpleInput.GetButtonDown(DashButton);

        public bool IsAttackButtonUp() => 
            SimpleInput.GetMouseButtonDown(0);

        protected Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(HorizontalAxis), SimpleInput.GetAxis(VerticalAxis));
    }
}
