using Assets.CodeBase.GameLogic.BombLogic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private float _deathTimer;
        private Bomb _bomb;

        [Inject]
        public void Construct(Bomb bomb)
        {
            _bomb = bomb;
        }
        
        public void Die()
        {
            _bomb.IncreaseDuration(2.0f);
            StartCoroutine(DestroyTimer());
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(_deathTimer);
            Destroy(gameObject);
        }
    }
}
