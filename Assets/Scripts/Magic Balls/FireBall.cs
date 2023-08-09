using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private float _lifeTime;

    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);
        Explode();
    }

    private void Update()
    {
        _lifeTime += Time.deltaTime;

        if (_lifeTime >= _maxLifeTime)
            Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.GetComponentInParent<Player>() == null)
            {
                Rigidbody rigitbody = collider.GetComponentInParent<Rigidbody>();

                if (rigitbody != null)
                    rigitbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }

        Instantiate(ExplodeParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
