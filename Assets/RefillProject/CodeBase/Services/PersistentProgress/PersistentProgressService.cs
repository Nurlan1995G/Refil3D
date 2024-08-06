using Assets.RefillProject.CodeBase.Data;

namespace Assets.RefillProject.CodeBase.Services
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
