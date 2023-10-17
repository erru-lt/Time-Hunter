using Assets.CodeBase.GameLogic.Spawner;
using Assets.CodeBase.StaticData;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("CollectLevelData"))
            {
                levelData.EnemySpawners = FindObjectsOfType<EnemySpawnMarker>()
                    .Select(x => new EnemySpawnerStaticData(x.GetComponent<SpawnerUniqueId>().Id, x.EnemyTypeId, x.transform.position))
                    .ToList();

                levelData.LevelName = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }
    }
}
