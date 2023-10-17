using Assets.CodeBase.GameLogic.BombLogic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private CapsuleCollider _capsuleCollider;
        [SerializeField] private GameObject _bloodFx;
        [SerializeField] private float _deathTimer;
        [SerializeField] private float _effectiveDistance;
        private Bomb _bomb;

        //[Inject]
        //public void Construct(Bomb bomb)
        //{
        //    _bomb = bomb;
        //}

        public void Die()
        {
            DisableRigidbody();
            _enemyAnimator.PlayDeathAnimation();
            InstantiateFx();
            StartCoroutine(DestroyTimer());

            _bomb.IncreaseDuration(2.0f);
        }

        private void DisableRigidbody() => 
            _capsuleCollider.enabled = false;

        private void InstantiateFx() =>
            Instantiate(_bloodFx, FxSpawnPoint(), Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(_deathTimer);
            Destroy(gameObject);
        }

        private Vector3 FxSpawnPoint() =>
            new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
                transform.forward * _effectiveDistance;
    }
}
