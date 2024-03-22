using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;

    private Animator dragonAnimator;

    private void OnEnable()
    {
        fixedJoystick = FindAnyObjectByType<FixedJoystick>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
        dragonAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yVal = fixedJoystick.Vertical;

        Vector3 movement = new Vector3 (xVal, 0, yVal); //converting movement into x-z plane
        rigidBody.velocity = movement * speed;

        if (xVal != 0 && yVal != 0)
        {
            dragonAnimator.SetBool("isFlying", true);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
        else
        {
            dragonAnimator.SetBool("isFlying", false);
        }
    }
}
