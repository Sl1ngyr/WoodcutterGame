using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;  
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    
    private bool _isRunning;
    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position +
                               new Vector3(moveSpeed * joystick.Horizontal * Time.fixedDeltaTime, 0,
                                   joystick.Vertical * moveSpeed * Time.fixedDeltaTime));
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if (!_isRunning)
            {
                animator.SetBool("isRunning", true);
                _isRunning = true;
            }

            rigidBody.MoveRotation(Quaternion.Euler(0,
                Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, 0));
        }
        else
        {
            if (_isRunning)
            {
                _isRunning = false;
                animator.SetBool("isRunning", false);
            }
        }
    }
}
    








