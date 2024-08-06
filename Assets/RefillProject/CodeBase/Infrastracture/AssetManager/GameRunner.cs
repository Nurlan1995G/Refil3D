using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.AssetManager
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstrapper GameBootstrapper;

        private void Awake()
        {
            GameBootstrapper gameBootstrapper = FindObjectOfType<GameBootstrapper>();   

            if (gameBootstrapper == null)
                Instantiate(GameBootstrapper);
        }
    }
}