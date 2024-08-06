using System.Collections.Generic;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "LevelData",menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<BuyerSpawnerData> BuyerSpawners;
        public Vector3 InitialRefillPosition;
        public Vector3 InitialPetrolPosition;
    }
}