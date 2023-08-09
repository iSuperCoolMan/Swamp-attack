using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform _followingTransform;
    [SerializeField] private float _followOnMouseMultiplier = 5f;

    private Vector3 _startPosition;
    private Vector3 _offset;
    private MousePositionGetter _mousePositionGetter;

    private void Start()
    {
        _mousePositionGetter = new MousePositionGetter();
        _startPosition = transform.position - _followingTransform.position;
    }

    private void Update()
    {
        _offset = _mousePositionGetter.GetVector3From(_followingTransform, Vector3.up) / _followOnMouseMultiplier;
        transform.position = _startPosition + _followingTransform.position + _offset;
    }
}