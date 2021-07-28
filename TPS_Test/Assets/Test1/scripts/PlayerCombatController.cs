using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(ReadPlayerInput))]
public class PlayerCombatController : MonoBehaviour
{
    [SerializeField] private float aimSpeed;
    [SerializeField] private Rig torsoRotationWeight;

    private float _currentTorsoWeight;

    private ReadPlayerInput _playerInput;
    private Animator _charAnimator;
    private void Awake()
    {
        _playerInput = GetComponent<ReadPlayerInput>();
        _charAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        _charAnimator.SetBool("aiming", _playerInput.Aiming);

        if (_playerInput.Aiming)
        {
            _currentTorsoWeight = Mathf.MoveTowards(_currentTorsoWeight, 1f, aimSpeed);
        }
        else 
        {
            _currentTorsoWeight = Mathf.MoveTowards(_currentTorsoWeight, 0f, aimSpeed);
        }

        torsoRotationWeight.weight = _currentTorsoWeight;
    }
}
