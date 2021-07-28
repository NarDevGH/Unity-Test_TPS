using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadPlayerInput : MonoBehaviour
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

    private Vector2 _moveDirectionInput;
    public Vector2 MoveDirectionInput
    {
        get { return _moveDirectionInput; }
    }

    private void Start()
    {
        _aiming = false;
        _sprinting = false;
        _moveDirectionInput = Vector2.zero;
    }

    public void OnMove(InputValue value)
    {
        _moveDirectionInput = value.Get<Vector2>();
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
        #region MoveSpeed

        _moveSpeed = _moveDirectionInput.magnitude;

        if (!_sprinting || _aiming)
        {
            _moveSpeed = Mathf.Clamp(_moveSpeed, 0f, 0.5f);
        }

        #endregion
    }
}
