using Assets.RefillProject.CodeBase.Data;

namespace Assets.RefillProject.CodeBase.Services
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}