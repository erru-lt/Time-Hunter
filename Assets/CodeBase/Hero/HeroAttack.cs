using Assets.CodeBase.Enemy;
using Assets.CodeBase.GameLogic;
using Assets.CodeBase.Services.Input;
using System;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator), typeof(CharacterController))]
    public class HeroAttack : MonoBehaviour
    {
        private const string HittableLayer = "Hittable";

        [SerializeField] private float _attackRadius;
        [SerializeField] private HeroAnimator _animator;
        [SerializeField] private CharacterController _characterController;
        
        private Collider[] _hits = new Collider[2]; 
        private IInputService _inputService;
        private bool _isAttacking;
        private int _enemyLayer;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _enemyLayer = 1 << LayerMask.NameToLayer(HittableLayer);
        }

        private void Update()
        {
            if(_inputService.IsAttackButtonUp() && _isAttacking == false)
            {
                _animator.PlayHitAnimation();
            }
        }
        
        private void OnAttack()
        {
            PhysicsDebug.DrawDebug(StartAttackPosition() + transform.forward, _attackRadius, 1);
            for (int i = 0; i < Hits(); ++i)
            {
                _hits[i].transform.parent.GetComponent<EnemyDeath>().Die();
            }
        }

        private int Hits() => 
            Physics.OverlapSphereNonAlloc(StartAttackPosition() + transform.forward, _attackRadius, _hits, _enemyLayer);

        private Vector3 StartAttackPosition() =>
            new Vector3(transform.position.x, _characterController.center.y / 2, transform.position.z);
    }
}
