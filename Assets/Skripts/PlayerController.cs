using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public FixedJoystick Joystick;
    private float speed = 5f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        Vector3 localVelocity = new Vector3(Joystick.Horizontal * speed, 0, Joystick.Vertical * speed);

        // ѕреобразуем локальный вектор в глобальный
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        rb.velocity = globalVelocity;

    }
}
