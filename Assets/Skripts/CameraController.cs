using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotationSpeed = 0.08f;
    private Vector2 lastTouchPosition;
    private float minVerticalAngle = -80f; 
    private float maxVerticalAngle = 80f;  
    private float currentVerticalAngle = 0f;

    public PanelTouchController panelContr;


    void Update()
    {


        if (panelContr.isPressed)
        {

            foreach (Touch touch in Input.touches)
            {
                if (touch.fingerId == panelContr.fingerId)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        lastTouchPosition = touch.position;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        Vector2 deltaPosition = touch.position - lastTouchPosition;

                        transform.Rotate(Vector3.up, deltaPosition.x * rotationSpeed);

                        currentVerticalAngle -= deltaPosition.y * rotationSpeed;
                        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);
                        transform.localEulerAngles = new Vector3(currentVerticalAngle, transform.localEulerAngles.y, 0);

                        lastTouchPosition = touch.position;
                    }
                }
            }


        }
    }
}
