using Assets.CodeBase.StaticData;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string LevelStaticDataPath = "StaticData/Level";

        private Dictionary<string, LevelStaticData> _levels;

        public void Load()
        {
            LoadLevelData();
        }

        public LevelStaticData ForLevel(string levelName) =>
            _levels.TryGetValue(levelName, out LevelStaticData levelData)
                ? levelData
                : null;

        private void LoadLevelData()
        {
            _levels = Resources
                .LoadAll<LevelStaticData>(LevelStaticDataPath)
                .ToDictionary(x => x.LevelName, x => x);
        }

    }
}