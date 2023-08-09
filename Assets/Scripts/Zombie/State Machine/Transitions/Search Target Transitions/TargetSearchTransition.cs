using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetSearchTransition : Transition
{
    [SerializeField] protected float Radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, 0, transform.position.z), Radius);
    }

    protected bool SearchTargetInRadius(float radius)
    {
        return Vector3.Distance(Target.transform.position, transform.position) <= radius;
    }
}
