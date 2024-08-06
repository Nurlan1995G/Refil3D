using Assets.RefillProject.CodeBase.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticBuyerPath = "StatiData/Buyers";
        private const string LevelDataPath = "StatiData/Levels";

        private Dictionary<BuyerTypeId, BuyerStaticData> _buyers;
        private Dictionary<string, LevelStaticData> _levels;

        public void LoadBuyers()
        {
            _buyers = Resources.LoadAll<BuyerStaticData>(StaticBuyerPath)
                .ToDictionary(x => x.BuyerTypeId, x => x);

            _levels = Resources.LoadAll<LevelStaticData>(LevelDataPath)
                .ToDictionary(x => x.LevelKey, x => x);    
        }

        public BuyerStaticData ForBuyer(BuyerTypeId buyerTypeId) => 
            _buyers.TryGetValue(buyerTypeId, out BuyerStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;
    }
}