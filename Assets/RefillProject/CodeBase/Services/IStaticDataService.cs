using Assets.RefillProject.CodeBase.StaticData;

namespace Assets.RefillProject.CodeBase.Services
{
    public interface IStaticDataService : IService
    {
        BuyerStaticData ForBuyer(BuyerTypeId buyerTypeId);
        LevelStaticData ForLevel(string sceneKey);
        void LoadBuyers();
    }
}