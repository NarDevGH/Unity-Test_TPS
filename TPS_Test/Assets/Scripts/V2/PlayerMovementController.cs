using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ReadPlayerInput))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] public float aceleration = 0.05f;
    [SerializeField] private float turnSpeed = 0.1f;
    [SerializeField] private Transform camTransform;

    private float _targetMoveSpeed;
    private float _currentMoveSpeed;

    private Vector2 _targetMoveDirection;
    private Vector2 _currentMoveDirection;

    float targetAngle;
    float turnSmoothVelocity;

    private ReadPlayerInput _playerInput;
    private Animator _charAnimator;

    private void Awake()
    {
        _charAnimator = GetComponent<Animator>();
        _playerInput = GetComponent<ReadPlayerInput>();
    }

    private void Start()
    {
        _targetMoveDirection = Vector2.zero;
        _targetMoveSpeed = 0f;
    }

    void Update()
    {

        #region Character Speed;

        _targetMoveSpeed = _playerInput.MoveSpeed;

        if (_currentMoveSpeed != _targetMoveSpeed) 
        {
            _currentMoveSpeed = Mathf.MoveTowards(_currentMoveSpeed, _targetMoveSpeed, aceleration); //smooths the transition between speeds

            _charAnimator.SetFloat("currentSpeed", _currentMoveSpeed);
        }


        #endregion

        #region Character Move Direction


        _targetMoveDirection = _playerInput.MoveDirectionInput;

        if (_currentMoveDirection != _targetMoveDirection) 
        {
            _currentMoveDirection = Vector2.MoveTowards(_currentMoveDirection, _targetMoveDirection, aceleration); //smooths the transition between directions

            _charAnimator.SetFloat("xDirection", _currentMoveDirection.x);
            _charAnimator.SetFloat("yDirection", _currentMoveDirection.y);     
        }


        #endregion


        if (_playerInput.MoveSpeed > 0 || _playerInput.Aiming)
        {
            targetAngle = transform.rotation.y + camTransform.eulerAngles.y;
        }

        transform.rotation = Quaternion.Euler(0f,
                                              Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeed),
                                              0f);
    }
}
