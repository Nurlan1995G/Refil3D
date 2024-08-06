using UnityEngine;

namespace Assets.RefillProject.CodeBase.Services.Input.Jostick
{
    public abstract class InputService : IInputService
    {
        protected const string Vertical = "Vertical";
        protected const string Horizontal = "Horizontal";

        public abstract Vector2 Axis { get; }

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}
