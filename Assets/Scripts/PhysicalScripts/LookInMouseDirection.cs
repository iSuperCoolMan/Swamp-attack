using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class LookInMouseDirection : MonoBehaviour
{
    [SerializeField] private ConfigurableJoint _spineJoint;
    [SerializeField] private PhysicalBodyPart _physicalBodyPart;

    private Player _player;
    private MousePositionGetter _mousePositionGetter;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _mousePositionGetter = new MousePositionGetter();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            LookForward();
        else if (Input.GetKeyDown(KeyCode.Mouse0))
            StopLookForward();
        else if (Input.GetKey(KeyCode.Mouse0))
            LookOnCursor();
    }

    private void LookOnCursor()
    {
        Quaternion targetRotation = _mousePositionGetter.Get3DRotationFrom(transform, Vector3.up);
        Quaternion targetRotationOnBody = targetRotation *
            Quaternion.Inverse(_player.transform.localRotation);
        _spineJoint.targetRotation = Quaternion.Inverse(targetRotationOnBody);
    }

    private void LookForward()
    {
        _physicalBodyPart.enabled = true;
    }

    private void StopLookForward()
    {
        _physicalBodyPart.enabled = false;
    }
}
