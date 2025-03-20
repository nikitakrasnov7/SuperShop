using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public FixedJoystick Joystick;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(Joystick.Vertical, 0, -Joystick.Horizontal);

    }
}
