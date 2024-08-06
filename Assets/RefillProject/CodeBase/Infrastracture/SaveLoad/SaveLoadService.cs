using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService persistentProgress, IGameFactory gameFactory)
        {
            _persistentProgress = persistentProgress;
            _gameFactory = gameFactory;
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialize<PlayerProgress>();

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_persistentProgress.PlayerProgress);

            PlayerPrefs.SetString(ProgressKey, _persistentProgress.PlayerProgress.ToJson());
        }
    }
}