using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Services;

namespace Assets.RefillProject.CodeBase.Infrastracture.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}