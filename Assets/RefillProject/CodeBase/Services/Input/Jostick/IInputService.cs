using UnityEngine;

namespace Assets.RefillProject.CodeBase.Services.Input.Jostick
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }
    }
}