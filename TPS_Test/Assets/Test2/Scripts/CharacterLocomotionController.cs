using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterLocomotionController : MonoBehaviour
{
    public float aceleration = 0.05f;

    [HideInInspector] public float _targetMoveSpeed;
    [HideInInspector] public Vector2 _targetMoveDirection;

    private float _currentMoveSpeed;
    private Vector2 _currentMoveDirection;

    private Animator _charAnimator;

    private void Awake()
    {
        _charAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        _targetMoveDirection = Vector2.zero;
        _targetMoveSpeed = 0f;
    }

    void Update()
    {

        #region Character Speed;

        if (_currentMoveSpeed != _targetMoveSpeed)
        {
            _currentMoveSpeed = Mathf.MoveTowards(_currentMoveSpeed, _targetMoveSpeed, aceleration); //smooths the transition between speeds

            _charAnimator.SetFloat("currentSpeed", _currentMoveSpeed);
        }


        #endregion

        #region Character Move Direction

        if (_currentMoveDirection != _targetMoveDirection)
        {
            _currentMoveDirection = Vector2.MoveTowards(_currentMoveDirection, _targetMoveDirection, aceleration); //smooths the transition between directions

            _charAnimator.SetFloat("xDirection", _currentMoveDirection.x);
            _charAnimator.SetFloat("yDirection", _currentMoveDirection.y);
        }


        #endregion

    }
}
