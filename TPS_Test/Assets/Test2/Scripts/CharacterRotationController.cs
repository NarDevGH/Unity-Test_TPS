using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotationController : MonoBehaviour
{

    public float turnSpeed = 0.1f;
    [HideInInspector] public float targetAngle;

    float turnSmoothVelocity;

    // Start is called before the first frame update
    private void Awake()
    {
        targetAngle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.y != targetAngle) 
        {
            transform.rotation = Quaternion.Euler(0f,
                                                  Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeed),
                                                  0f);
        }
    }
}
