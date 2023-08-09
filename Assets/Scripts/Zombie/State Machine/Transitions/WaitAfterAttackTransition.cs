using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAfterAttackTransition : Transition
{
    private float _attackSpeed;
    private float _timeToNextAttack;

    private void Awake()
    {
        _attackSpeed = GetComponent<Zombie>().AttackSpeed;
        _timeToNextAttack = _attackSpeed;
    }

    private void Update()
    {
        if (_timeToNextAttack <= 0)
        {
            _timeToNextAttack = _attackSpeed;
            NeedTranzit = true;
        }

        _timeToNextAttack -= Time.deltaTime;
    }
}
