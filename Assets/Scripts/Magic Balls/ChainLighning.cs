using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLighning : Projectile
{
    [SerializeField] private int _bounces;
    [SerializeField] private float _bounceRange;

    private float _passedRange;
    private int _passedBounces;
    private Zombie _currentTarget;
    private Vector3 _startPosition;

    protected override void OnTriggerEnter(Collider collider)
    {
        Zombie target = collider.GetComponentInParent<Zombie>();

        if (target != null && target != _currentTarget)
        {
            target.Health.Damage(Damage);
            _currentTarget = target;
            transform.position = collider.transform.position;
            BounceToNextTarget();
            _passedRange = 0;
            _startPosition = transform.position;

            if (_passedBounces >= _bounces)
                Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_passedRange >= _bounceRange)
        {
            Explode();
            _passedRange -= _bounceRange;
            _startPosition = transform.position;

            if (_passedBounces >= _bounces)
                Destroy(gameObject);
        }

        _passedRange = Vector3.Distance(_startPosition, transform.position);
    }

    private void Explode()
    {
        Instantiate(ExplodeParticle, transform.position, Quaternion.identity);
        _passedBounces++;
    }

    private void BounceToNextTarget()
    {
        Explode();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _bounceRange);

        foreach (Collider collider in colliders)
        {
            Zombie nextTarget = collider.GetComponentInParent<Zombie>();

            if (nextTarget != null && nextTarget != _currentTarget)
            {
                Body.velocity = (collider.transform.position - transform.position).normalized * Speed;
                break;
            }
        }
    }
}
