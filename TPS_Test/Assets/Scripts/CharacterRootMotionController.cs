using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterRootMotionController : MonoBehaviour
{
    [SerializeField] public float aceleration = 0.05f;

    [HideInInspector] public float TargetMoveSpeed;
    private float _currentMoveSpeed;

    [HideInInspector]public Vector2 TargetMoveDirection;
    private Vector2 _currentMoveDirection;

    private Animator charAnimator;

    private void Awake()
    {
        charAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        TargetMoveDirection = Vector2.zero;
        TargetMoveSpeed = 0f;
    }

    void Update()
    {

        #region Character Speed;


        if (_currentMoveSpeed != TargetMoveSpeed) 
        {
            _currentMoveSpeed = Mathf.MoveTowards(_currentMoveSpeed, TargetMoveSpeed, aceleration); //smooths the transition between speeds

            charAnimator.SetFloat("currentSpeed", _currentMoveSpeed);
        }


        #endregion

        #region Character Move Direction

        if (_currentMoveDirection != TargetMoveDirection) 
        {
            _currentMoveDirection = Vector2.MoveTowards(_currentMoveDirection, TargetMoveDirection, aceleration); //smooths the transition between directions

            charAnimator.SetFloat("xDirection", _currentMoveDirection.x);
            charAnimator.SetFloat("yDirection", _currentMoveDirection.y);     
        }


        #endregion

    }
}
