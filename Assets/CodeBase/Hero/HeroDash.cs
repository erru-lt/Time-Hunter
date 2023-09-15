using Assets.CodeBase.Services.Input;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Hero
{
    public class HeroDash : MonoBehaviour
    {
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashTime;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private HeroMove _heroMove;
        [SerializeField] private HeroAnimator _heroAnimator;
        private IInputService _inputService;
        private bool _isDashing;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            Dash();
        }

        private void Dash()
        {
            if (_inputService.GetDashButton() && _isDashing == false)
            {
                StartCoroutine(Dashing());
            }
        }

        private IEnumerator Dashing()
        {
            _isDashing = true;

            float originalSpeed = _heroMove.MoveSpeed;
            float startTime = Time.time;

            _heroMove.MoveSpeed = _dashSpeed;

            while (Time.time <= startTime + _dashTime)
            {
                //transform.localScale = Vector3.zero;
                _heroAnimator.IncreaseRunAnimationSpeed();
                _characterController.Move(_heroMove.MoveSpeed * transform.forward * Time.deltaTime);
                yield return null;
            }

            //transform.localScale = Vector3.one;
            _heroAnimator.DecreaseAnimationSpeed();
            _heroMove.MoveSpeed = originalSpeed;
            _isDashing = false;
        }
    }
}
