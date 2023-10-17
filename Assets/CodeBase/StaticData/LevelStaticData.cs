using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName ="StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelName;
        public List<EnemySpawnerStaticData> EnemySpawners;
    }
}
