using UnityEngine;

namespace Assets.CodeBase.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string HorizontalAxis = "Horizontal";
        protected const string VerticalAxis = "Vertical";

        public abstract Vector2 Axis { get; }

        public bool GetDashButton() =>
            SimpleInput.GetMouseButtonDown(0);

        protected Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(HorizontalAxis), SimpleInput.GetAxis(VerticalAxis));
    }
}
