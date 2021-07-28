using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterCombatController : MonoBehaviour
{
    [SerializeField] private float aimSpeed;
    [SerializeField] private Rig torsoRotationWeight;

    [HideInInspector] public bool aiming;

    private float _currentTorsoWeight;

    private Animator _charAnimator;
    private void Awake()
    {
        _charAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        _charAnimator.SetBool("aiming", aiming);

        if (aiming)
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
