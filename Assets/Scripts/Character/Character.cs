using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private ParticleSystem _blood;

    public IHealth Health => _health;

    private void OnEnable()
    {
        _health.Damaged += Bleed;
        _health.Finished += Die;
    }

    private void OnDisable()
    {
        _health.Damaged -= Bleed;
        _health.Finished -= Die;
    }

    protected void InitCharacter()
    {
        _health.Init();
    }

    private void Bleed()
    {
        Instantiate(_blood, transform.position, Quaternion.identity);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
