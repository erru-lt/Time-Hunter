using UnityEngine;

namespace Assets.CodeBase.GameLogic
{
    public static class PhysicsDebug
    {
        public static void DrawDebug(Vector3 worldPos, float radius, float duration)
        {
            Debug.DrawRay(worldPos, Vector3.up * radius, Color.red, duration);
            Debug.DrawRay(worldPos, Vector3.down * radius, Color.red, duration);
            Debug.DrawRay(worldPos, Vector3.left * radius, Color.red, duration);
            Debug.DrawRay(worldPos, Vector3.right * radius, Color.red, duration);
            Debug.DrawRay(worldPos, Vector3.forward * radius, Color.red, duration);
            Debug.DrawRay(worldPos, Vector3.back * radius, Color.red, duration);
        }
    }
}
