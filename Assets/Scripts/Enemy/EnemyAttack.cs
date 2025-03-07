using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackRange;

    [SerializeField] private GameObject player;

    public float AttackRange => _attackRange;

    public int TryAttackPlayer()
    {
        return 15;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
