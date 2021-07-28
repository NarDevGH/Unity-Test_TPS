using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementInputController))]
public class CharacterRotationController : MonoBehaviour
{

    [SerializeField] private Transform camTransform;
    [SerializeField] private float turnSpeed = 0.1f;

    float targetAngle;
    float turnSmoothVelocity;

    private PlayerMovementInputController playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerMovementInputController>();
    }


    void Update()
    {
        if (playerInput.MoveSpeed > 0 || playerInput.Aiming)
        {
            targetAngle = transform.rotation.y + camTransform.eulerAngles.y;
        }

        transform.rotation = Quaternion.Euler(0f,
                                              Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeed),
                                              0f);
    }
}
