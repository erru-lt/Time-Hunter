using Assets.CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Hero
{
    //[RequireComponent(typeof(Animator), typeof(CharacterController))]
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int RunHash = Animator.StringToHash("Run");
        private static readonly int AttackHash = Animator.StringToHash("Attack");

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            _animator.SetFloat(RunHash, _inputService.Axis.sqrMagnitude, 0.1f, Time.deltaTime);
            //PlayRunAnimation();
            //Debug.Log("Anim" + _characterController.velocity.magnitude);
        }

        public void PlayHitAnimation() => 
            _animator.SetTrigger(AttackHash);

        public void IncreaseRunAnimationSpeed() => 
            _animator.speed = 2;

        public void DecreaseAnimationSpeed() => 
            _animator.speed = 1;

        private void PlayRunAnimation() =>
            _animator.SetFloat(RunHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
    }
}
