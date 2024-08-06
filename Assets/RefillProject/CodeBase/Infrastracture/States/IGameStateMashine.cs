using Assets.RefillProject.CodeBase.Services;

namespace Assets.RefillProject.CodeBase.Infrastracture.States
{
    public interface IGameStateMashine : IService
    {
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
        void Enter<TState>() where TState : class, IState;
    }
}