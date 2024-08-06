using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Infrastracture.SaveLoad;
using Assets.RefillProject.CodeBase.Logic;
using Assets.RefillProject.CodeBase.Services;
using System;
using System.Collections.Generic;

namespace Assets.RefillProject.CodeBase.Infrastracture.States
{
    public class GameStateMashine : IGameStateMashine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMashine(SceneLoader sceneLoader, LoadingCurtain curtain, AllService services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain, services.Single<IGameFactory>()
                ,services.Single<IPersistentProgressService>(),services.Single<IStaticDataService>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this,services.Single<IPersistentProgressService>()
                ,services.Single<ISaveLoadService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }


        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetStated<TState>();
            _activeState = state;
            return state;
        }

        private TState GetStated<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}