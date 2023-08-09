using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zombie : Character
{
    [SerializeField] private Player _target;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _reward;

    public Player Target => _target;
    public int Damage => _damage;
    public float AttackSpeed => _attackSpeed;

    private void Start()
    {
        InitCharacter();
    }

    public void Init(Player target)
    {
        _target = target;
        Health.Finished += AddReward;
    }

    private void AddReward()
    {
        _target.AddReward(_reward);
    }
}
