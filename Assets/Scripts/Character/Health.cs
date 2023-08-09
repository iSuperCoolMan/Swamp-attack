using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Health : IHealth
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction<int, int> Changed;
    public event UnityAction Damaged;
    public event UnityAction Finished;

    public void Init()
    {
        _currentHealth = _maxHealth;
        Changed?.Invoke(_currentHealth, _maxHealth);
    }

    public void Damage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        Damaged?.Invoke();
        Changed?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Finished?.Invoke();
    }
}

public interface IHealth
{
    public event UnityAction<int, int> Changed;
    public event UnityAction Finished;

    public void Damage(int damage);
}