using UnityEngine;

namespace Assets.CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private HeroAnimator _animator;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _animator.PlayHitAnimation();
            }
        }

        private void OnAttack()
        {
            Debug.Log("hit !");
        }
    }
}
