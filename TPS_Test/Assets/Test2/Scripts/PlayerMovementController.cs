using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterLocomotionController))]
[RequireComponent(typeof(CharacterRotationController))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private Transform playerCam;

    private bool _aiming;
    private bool _sprinting;
    private float _moveSpeed;
    private Vector2 _moveDirectionInput;

    private CharacterLocomotionController locomotionController;
    private CharacterRotationController rotationController;
    private void Awake()
    {
        locomotionController = GetComponent<CharacterLocomotionController>();
        rotationController = GetComponent<CharacterRotationController>();
    }

    private void Start()
    {
        _aiming = false;
        _sprinting = false;
        _moveDirectionInput = Vector2.zero;
    }

    #region Read Input

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

    #endregion


    private void RotateTowardsCameraDir()
    {
        rotationController.targetAngle = transform.rotation.y + playerCam.eulerAngles.y;
    }

    private void Update()
    {

        locomotionController._targetMoveDirection = _moveDirectionInput;

        #region Move Speed

        _moveSpeed = _moveDirectionInput.magnitude;

        if (!_sprinting || _aiming)
        {
            _moveSpeed = Mathf.Clamp(_moveSpeed, 0f, 0.5f);
        }

        locomotionController._targetMoveSpeed = _moveSpeed;

        #endregion

        if (_moveSpeed > 0 || _aiming)
        {
            RotateTowardsCameraDir();
        }

    }
}
