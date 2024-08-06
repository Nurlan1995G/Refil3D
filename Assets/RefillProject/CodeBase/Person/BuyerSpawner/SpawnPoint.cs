using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.StaticData;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Person.BuyerSpawner
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        public BuyerTypeId BuyerTypeId;
        private IGameFactory _gameFactory;

        public bool IsServiced;
        
        public string Id { get; set; }

        public void Construct(IGameFactory gameFactory) =>
            _gameFactory = gameFactory;

        public void LoadProgress(PlayerProgress progress)
        {
            Spawn();
        }

        public void UpdateProgress(PlayerProgress progress)
        {

        }

        private void Spawn() => 
             _gameFactory.CreateBuyer(BuyerTypeId, transform);
    }
}
