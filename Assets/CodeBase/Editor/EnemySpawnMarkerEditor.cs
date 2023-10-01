using Assets.CodeBase.GameLogic.Spawner;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySpawnMarker))]
public class EnemySpawnMarkerEditor : Editor
{
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void Draw(EnemySpawnMarker marker, GizmoType gizmo)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(marker.transform.position, 1.0f);
    }
}
