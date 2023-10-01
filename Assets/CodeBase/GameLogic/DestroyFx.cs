using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.GameLogic
{
    public class DestroyFx : MonoBehaviour
    {
        [SerializeField] private readonly int _destroyTimer = 1;

        private void Start()
        {
            StartCoroutine(DestroyTimer());
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(_destroyTimer);
            Destroy(gameObject);
        }
    }
}
