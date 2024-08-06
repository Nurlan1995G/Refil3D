using Assets.RefillProject.CodeBase.Infrastracture.States;
using Assets.RefillProject.CodeBase.Logic;
using Assets.RefillProject.CodeBase.Services;

namespace Assets.RefillProject.CodeBase.Infrastracture.AssetManager
{
    public class Game
    {
        public GameStateMashine GameStateMashine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            GameStateMashine = new GameStateMashine(new SceneLoader(coroutineRunner),loadingCurtain, AllService.Container);
        }
    }
}
