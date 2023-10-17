using Assets.CodeBase.StaticData;

namespace Assets.CodeBase.Services.StaticData
{
    public interface IStaticDataService
    {
        LevelStaticData ForLevel(string levelName);
        void Load();
    }
}