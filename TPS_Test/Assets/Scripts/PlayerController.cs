using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterRootMotionController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camTransform;
    [SerializeField] private float turnSpeed;

    private bool _aiming;
    private bool _sprinting;
    private float _moveSpeed;
    private Vector2 _inputMoveDirection;

    float targetAngle;
    float turnSmoothVelocity;

    private CharacterRootMotionController motionController;

    private void Awake()
    {
        motionController = GetComponent<CharacterRootMotionController>();
    }

    private void Start()
    {
        _aiming = false;
        _sprinting = false;
        _inputMoveDirection = Vector2.zero;
    }

    public void OnMove(InputValue value) 
    {
        _inputMoveDirection = value.Get<Vector2>();
    }

    public void OnSprint() 
    {
        _sprinting = !_sprinting;
    }
    public void OnAim()
    {
        _aiming = !_aiming;
    }

    private void Update()
    {
        #region Input MoveDirection

        motionController.TargetMoveDirection = _inputMoveDirection;

        #endregion

        #region Input MoveSpeed

        _moveSpeed = _inputMoveDirection.magnitude;

        if (!_sprinting || _aiming)
        {
            _moveSpeed = Mathf.Clamp(_moveSpeed, 0f, 0.5f);
        }

        motionController.TargetMoveSpeed = _moveSpeed;

        #endregion


        if (_moveSpeed > 0 || _aiming)
        {
            targetAngle = transform.rotation.y + camTransform.eulerAngles.y;
        }

        transform.rotation = Quaternion.Euler(0f,
                                              Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeed),
                                              0f);
    }
}
