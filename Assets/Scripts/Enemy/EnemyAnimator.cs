using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int RecieveDamage = Animator.StringToHash("ReceiveDamage");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Walk = Animator.StringToHash("IsWalking");

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void isWalking(bool condition)
    {
        _animator.SetBool(Walk, condition);
    }

    public void PlayReceiveDamage()
    {
        _animator.SetTrigger(RecieveDamage);
    }

    public void PlayDeath()
    {
        _animator.SetTrigger(Death);
    }
}
