using UnityEngine;

namespace Assets.RefillProject.CodeBase.Services.Input.Jostick
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}
