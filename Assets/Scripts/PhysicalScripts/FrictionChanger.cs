using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionChanger : MonoBehaviour
{
    [SerializeField] private PhysicMaterial _defaultMaterial;
    [SerializeField] private PhysicMaterial _zeroFrictionMaterial;

    [SerializeField] private Collider _leftCollider;
    [SerializeField] private Collider _rightCollider;

    public void LeftFriction()
    {
        _leftCollider.material = _defaultMaterial;
        _rightCollider.material = _zeroFrictionMaterial;
    }

    public void RightFriction()
    {
        _rightCollider.material = _defaultMaterial;
        _leftCollider.material = _zeroFrictionMaterial;
    }

    public void FullFriction()
    {
        _rightCollider.material = _defaultMaterial;
        _leftCollider.material = _defaultMaterial;
    }
}
