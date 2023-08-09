using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
public class PhysicalBodyPart : MonoBehaviour
{
    [SerializeField] private Transform _animatedClone;

    private ConfigurableJoint _configurableJoint;
    private Quaternion _startRotation;

    private void Start()
    {
        _configurableJoint = GetComponent<ConfigurableJoint>();
        _startRotation = transform.localRotation;
    }

    private void FixedUpdate()
    {
        _configurableJoint.targetRotation = Quaternion.Inverse(_animatedClone.localRotation) * _startRotation;
    }
}
