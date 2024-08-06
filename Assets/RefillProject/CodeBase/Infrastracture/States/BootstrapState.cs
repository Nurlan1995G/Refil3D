using Assets.RefillProject.CodeBase.Infrastracture.AssetManager;
using Assets.RefillProject.CodeBase.Infrastracture.AssetManagment;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Infrastracture.SaveLoad;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.Input.Jostick;
using Assets.RefillProject.CodeBase.StaticData;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";

        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private AllService _services;

        public BootstrapState(GameStateMashine gameStateMashine, SceneLoader sceneLoader, AllService services)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() =>
            _gameStateMashine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            RegisterStaticData();

            _services.RegisterSingle<IGameStateMashine>(_gameStateMashine);
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());

            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()
                ,_services.Single<IStaticDataService>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>()
                , _services.Single<IGameFactory>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadBuyers();
            _services.RegisterSingle(staticData);
        }

        private static IInputService InputService() =>
            Application.isEditor ? new StandoloneInputService() : new MobileInputService();
    }
}