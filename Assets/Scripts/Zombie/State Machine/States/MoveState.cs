using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
public class MoveState : State
{
    private ConfigurableJoint _configurableJoint;
    private Animator _animator;

    private void Awake()
    {
        _configurableJoint = GetComponent<ConfigurableJoint>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _animator.SetBool("Is Move", true);
        _animator.Play("Move");
    }

    private void OnDisable()
    {
        _animator.SetBool("Is Move", false);
    }

    private void FixedUpdate()
    {
        Vector3 toTarget = Target.transform.position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);
        Quaternion rotation = Quaternion.LookRotation(toTargetXZ);

        _configurableJoint.targetRotation = Quaternion.Inverse(rotation);
    }
}
