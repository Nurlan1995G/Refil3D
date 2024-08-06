using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.SaveLoad;
using Assets.RefillProject.CodeBase.Services;
using System;

namespace Assets.RefillProject.CodeBase.Infrastracture.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMashine _gameStateMashine;
        private readonly IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMashine gameStateMashine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMashine = gameStateMashine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMashine.Enter<LoadLevelState, string>(_progressService.PlayerProgress.WorldData.PositionOnLevel.Level);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress() => 
            new PlayerProgress(initialLevel: "Main");
    }
}