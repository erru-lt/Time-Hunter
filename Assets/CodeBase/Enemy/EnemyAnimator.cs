using UnityEngine;

namespace Assets.CodeBase.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int DeathHash = Animator.StringToHash("Death");
        private static readonly int EmergeHash = Animator.StringToHash("Emerge");
        private static readonly int AttackHash = Animator.StringToHash("Attack");

        [SerializeField] private Animator _animator;

        public void PlayDeathAnimation() => 
            _animator.SetTrigger(DeathHash);

        public void PlayEmergeFromCoverAnimation() => 
            _animator.SetTrigger(EmergeHash);

        public void PlayAttackAnimation() => 
            _animator.SetTrigger(AttackHash);
    }
}
