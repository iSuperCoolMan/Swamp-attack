using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Zombie))]
public class AttackState : State
{
    private int _damage;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _damage = GetComponent<Zombie>().Damage;
    }

    private void OnEnable()
    {
        Attack(Target);
        _animator.SetBool("Is Waiting Attack", true);
    }

    private void OnDisable()
    {
        _animator.SetBool("Is Waiting Attack", false);
    }

    private void Attack(Player target)
    {
        _animator.SetTrigger("Attack");
        target.Health.Damage(_damage);
    }
}
