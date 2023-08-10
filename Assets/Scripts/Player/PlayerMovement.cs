using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _bodyAnimated;
    [SerializeField] private UnityEvent _stopped;

    private Animator _animator;

    private DirectionButton[] _directionButtons;
    private Vector3 _currentDirection;
    private UnityAction _directionChanged;

    private KeyCode _up = KeyCode.W;
    private KeyCode _right = KeyCode.D;
    private KeyCode _down = KeyCode.S;
    private KeyCode _left = KeyCode.A;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _directionButtons = new DirectionButton[]
        {
            new DirectionButton("Up", _up, transform.forward),
            new DirectionButton("Left", _right, transform.right),
            new DirectionButton("Down", _down, -transform.forward),
            new DirectionButton("Right", _left, -transform.right)
        };
    }

    private void OnEnable()
    {
        _directionChanged += TryStartRun;
        _directionChanged += TryStop;
        _directionChanged += RotateToDirection;
    }

    private void OnDisable()
    {
        _directionChanged -= TryStartRun;
        _directionChanged -= TryStop;
        _directionChanged -= RotateToDirection;
    }

    private void Update()
    {
        ReadInputKey();
    }

    private void ReadInputKey()
    {
        foreach (DirectionButton button in _directionButtons)
        {
            if (Input.GetKeyUp(button.KeyCode))
                ChangeDirection(-button.Direction);

            if (Input.GetKeyDown(button.KeyCode))
                ChangeDirection(button.Direction);
        }
    }

    private void ChangeDirection(Vector3 direction)
    {
        _currentDirection += direction;
        _directionChanged.Invoke();
    }

    private void RotateToDirection()
    {
        if (_currentDirection != Vector3.zero)
            _bodyAnimated.localRotation = Quaternion.LookRotation(_currentDirection);
    }

    private void TryStartRun()
    {
        if (_currentDirection != Vector3.zero)
        {
            if (_animator.GetBool("Is Running") == false)
            {
                _animator.SetBool("Is Running", true);
                _animator.Play("Start Run");
            }
        }
    }

    private void TryStop()
    {
        if (_currentDirection == Vector3.zero)
        {
            _animator.SetBool("Is Running", false);
            _stopped.Invoke();
        }
    }
}
