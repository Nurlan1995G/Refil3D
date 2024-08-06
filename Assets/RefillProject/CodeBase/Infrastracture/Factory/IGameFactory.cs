using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgress> ProgressWriters { get; }
        List<ISavedProgressReader> ProgressReaders { get; }

        GameObject CreateRefill(Vector3 at);
        GameObject CreateBuyer(BuyerTypeId buyerTypeId, Transform parent);
        GameObject CreatePetrol(Vector3 at);
        void CreateSpawner(Vector3 at, string spawnerId, BuyerTypeId sbuyerTypeId);
        void CreateHud();
        void Cleanup();
    }
}