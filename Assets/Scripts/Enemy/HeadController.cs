using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private playerData data;

    private int healthPoints = 100;
    public bool isDead = false;

    private const string WEAPON_TAG = "Weapon";
    [SerializeField] private EnemyAnimator _enemyAnimator;

    [SerializeField] private EnemyAI _enemyAI;

    private void Start()
    {
        data = FindObjectOfType<playerData>();
    }
    private void Update()
    {
        if (healthPoints <= 0 && !isDead)
        {
            isDead = true;
            _enemyAI._currentState = EnemyStates.Dying;

            data.addKill();
            data.addScore(Random.Range(1, 4));

            _enemyAnimator.PlayDeath();
            Destroy(enemy, 5);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(WEAPON_TAG))
        {
            return;
        }
        healthPoints -= 30;
        _enemyAnimator.PlayReceiveDamage();
    }
}
