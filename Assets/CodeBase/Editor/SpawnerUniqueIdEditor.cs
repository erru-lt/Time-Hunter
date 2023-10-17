using Assets.CodeBase.GameLogic.Spawner;
using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(SpawnerUniqueId))]
    public class SpawnerUniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            SpawnerUniqueId uniqueId = (SpawnerUniqueId)target;

            if(string.IsNullOrEmpty(uniqueId.Id))
            {
                Generate(uniqueId);
            }
            else
            {
                SpawnerUniqueId[] uniqueIds = FindObjectsOfType<SpawnerUniqueId>();

                if(uniqueIds.Any(other => other != uniqueId && other.Id == uniqueId.Id))
                {
                    Generate(uniqueId);
                }
            }
        }

        private void Generate(SpawnerUniqueId uniqueId)
        {
            uniqueId.GenerateId();

            if(!Application.isPlaying)
            {
                EditorUtility.SetDirty(uniqueId);
                EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
            }
        }
    }
}
