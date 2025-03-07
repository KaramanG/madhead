using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

using Random = UnityEngine.Random;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;

    [SerializeField] private float _reachedPointDistance;

    [SerializeField] private GameObject _roamTarget;

    [SerializeField] private float _targetFollowRange;

    [SerializeField] private float _stopTargetFollowingRange;

    [SerializeField] private EnemyAttack _enemyAttack;

    [SerializeField] private AIDestinationSetter _aiDestinationSetter;

    [SerializeField] private EnemyAnimator _enemyAnimator;

    private Player _player;
    [SerializeField] private Rigidbody _rigidbody;

    public EnemyStates _currentState;
    private Vector3 _roamPosition;

    [SerializeField] private HeadController _headController;
    
    [SerializeField] private float maxTimer = 3f;
    private float _timer;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _currentState = EnemyStates.Roaming;
        _roamPosition = GenerateRoamPosition();
        _timer = 0f;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case EnemyStates.Roaming:
                if (!_headController.isDead)
                {
                    _rigidbody.constraints = RigidbodyConstraints.None;
                }
                
                _roamTarget.transform.position = _roamPosition;

                if (Vector3.Distance(gameObject.transform.position, _roamPosition) <= _reachedPointDistance)
                {
                    _roamPosition = GenerateRoamPosition();
                }

                _aiDestinationSetter.target = _roamTarget.transform;
                TryFindTarget();

                _enemyAnimator.isWalking(true);

                break;

            case EnemyStates.Following:
                if (!_headController.isDead)
                {
                    _rigidbody.constraints = RigidbodyConstraints.None;
                }

                _aiDestinationSetter.target = _player.transform;

                _enemyAnimator.isWalking(true);

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _enemyAttack.AttackRange)
                {
                    _enemyAnimator.isWalking(false);
                    _rigidbody.constraints = RigidbodyConstraints.FreezePosition;

                    _timer -= Time.deltaTime;

                    if (_timer < 0)
                    {
                        _enemyAnimator.PlayAttack();
                        _player.receiveDamage(_enemyAttack.TryAttackPlayer());
                        _timer = maxTimer + 80/30;
                    }                     
                }

                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) >= _stopTargetFollowingRange)
                {
                    _currentState = EnemyStates.Following;
                }
                break;

            case EnemyStates.Dying:
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;      
                break;
        }
    }

    private void TryFindTarget()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates.Following;
        }
    }

    private Vector3 GenerateRoamPosition()
    {
        var roamPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomWalkableDistance();
        return roamPosition;
    }

    private Vector3 GenerateRandomDirection()
    {
        var newDirection = new Vector3(Random.Range(-1f,1f), 0f, Random.Range(-1f,1f));
        return newDirection.normalized;
    }

    private float GenerateRandomWalkableDistance()
    {
        var randomDistance = Random.Range(_minWalkableDistance, _maxWalkableDistance);
        return randomDistance;
    }
}

public enum EnemyStates
{
    Roaming,
    Following,
    Dying
}