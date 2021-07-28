using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterRootMotionController))]
public class PlayerMovementInputController : MonoBehaviour
{
    private bool _aiming;
    public bool Aiming 
    { 
        get { return _aiming; } 
    }

    private bool _sprinting;
    public bool Sprinting 
    {
        get { return _sprinting; }
    }

    private float _moveSpeed;
    public float MoveSpeed 
    {
        get { return _moveSpeed; }
    }

    private Vector2 _inputMoveDirection;

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

    }
}
