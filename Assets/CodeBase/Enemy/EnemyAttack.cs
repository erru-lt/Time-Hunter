using Assets.CodeBase.Enemy;
using Assets.CodeBase.Hero;
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private float _shootDistance;
    private HeroMove _hero;
    private bool _isAiming;
    private bool _isShooting;

    [Inject]
    private void Construct(HeroMove hero)
    {
        _hero = hero;
    }

    private void Update()
    {
        if(_hero == null) return;
        CheckDistanceToHero();
        LookAtHero();
    }

    private void OnEmergeAnimation()
    {
        _isAiming = true;
    }

    private void LookAtHero()
    {
        if (_isAiming || _isShooting)
        {
            transform.LookAt(TargetPosition());
        }
    }

    private Vector3 TargetPosition() =>
        new Vector3(_hero.transform.position.x, transform.position.y, _hero.transform.position.z);

    private void CheckDistanceToHero()
    {
        float distance = Vector3.Distance(transform.position, _hero.transform.position);

        if (distance <= _shootDistance)
        {
            _enemyAnimator.PlayEmergeFromCoverAnimation();
            //transform.LookAt(_hero.transform.position);
        }

        if (distance <= _shootDistance / 2)
        {
            _isShooting = true;
            _enemyAnimator.PlayAttackAnimation();
        }
    }

    public class Factory : PlaceholderFactory<EnemyAttack>
    {

    }
}
