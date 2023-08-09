using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColliders : MonoBehaviour
{
    [SerializeField] private Collider[] _colliders;

    private Collider _currentCollider;

    private void Awake()
    {
        _currentCollider = GetComponent<Collider>();

        foreach(Collider collider in _colliders)
            Physics.IgnoreCollision(collider, _currentCollider);
    }
}
