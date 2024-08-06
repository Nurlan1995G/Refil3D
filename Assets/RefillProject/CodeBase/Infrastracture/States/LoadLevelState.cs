using Assets.RefillProject.CodeBase.CameraLogic;
using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Logic;
using Assets.RefillProject.CodeBase.Person.BuyerSpawner;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.RefillProject.CodeBase.Infrastracture.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMashine gameStateMashine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService persistentProgress, IStaticDataService staticData)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _persistentProgress = persistentProgress;
            _staticData = staticData;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReader();

            _gameStateMashine.Enter<GameLoopState>();
        }

        private void InformProgressReader()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_persistentProgress.PlayerProgress);
        }

        private void InitGameWorld()
        {
            LevelStaticData levelData = LevelStaticData();

            InitSpawners(levelData);
            GameObject refill = InitRefill(levelData);
            InitPetrol(levelData);
            InitHud();
            CameraFollow(refill);
        }

        private LevelStaticData LevelStaticData() =>
            _staticData.ForLevel(SceneManager.GetActiveScene().name);

        private void InitSpawners(LevelStaticData levelData)
        {
            foreach (BuyerSpawnerData spawnerData in levelData.BuyerSpawners)
                _gameFactory.CreateSpawner(spawnerData.Position, spawnerData.Id, spawnerData.BuyerTypeId);
        }

        private GameObject InitRefill(LevelStaticData levelData) =>
            _gameFactory.CreateRefill(levelData.InitialRefillPosition);

        private void InitPetrol(LevelStaticData levelData) => 
            _gameFactory.CreatePetrol(levelData.InitialPetrolPosition);
        
        private void InitHud() =>
            _gameFactory.CreateHud();

        private static void CameraFollow(GameObject refill) => 
            Camera.main.GetComponent<CameraFollow>().Follow(refill);
    }
}