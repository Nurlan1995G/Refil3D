using Assets.RefillProject.CodeBase.Infrastracture.States;
using Assets.RefillProject.CodeBase.Logic;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.AssetManager
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain CurtainPrefab;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(CurtainPrefab));
            _game.GameStateMashine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}