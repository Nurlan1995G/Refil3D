namespace Assets.RefillProject.CodeBase.Data
{
    public class PlayerProgress
    {
        public WorldData WorldData;
        public KillData KillData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            KillData = new KillData();
        }
    }
}
