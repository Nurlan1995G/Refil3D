using Assets.RefillProject.CodeBase.Infrastracture.States;
using Assets.RefillProject.CodeBase.Services;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Logic
{
    public class LevelTransferTrigger : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        public string TransferTo;

        private IGameStateMashine _gameStateMashine;
        private bool _triggered;

        private void Awake()
        {
            _gameStateMashine = AllService.Container.Single<IGameStateMashine>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_triggered)
                return;

            if (other.CompareTag(PlayerTag))
            {
                _gameStateMashine.Enter<LoadLevelState, string>(TransferTo);
                _triggered = true;
            }   
        }
    }
}