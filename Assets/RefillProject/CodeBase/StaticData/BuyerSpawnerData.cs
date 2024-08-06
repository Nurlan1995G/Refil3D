using System;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.StaticData
{
    [Serializable]
    public class BuyerSpawnerData
    {
        public string Id;
        public BuyerTypeId BuyerTypeId;
        public Vector3 Position;

        public BuyerSpawnerData(string id, BuyerTypeId buyerTypeId, Vector3 position)
        {
            Id = id;
            BuyerTypeId = buyerTypeId;
            Position = position;
        }
    }
}