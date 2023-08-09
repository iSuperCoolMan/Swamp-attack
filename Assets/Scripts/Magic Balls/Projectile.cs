using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;
    [SerializeField] protected ParticleSystemRenderer ExplodeParticle;
    
    protected Rigidbody Body;

    protected virtual void Start()
    {
        Body = GetComponent<Rigidbody>();
        Body.velocity = transform.forward * Speed;
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        var zombie = collider.GetComponentInParent<Zombie>();

        if (zombie != null)
            zombie.Health.Damage(Damage);
    }
}
