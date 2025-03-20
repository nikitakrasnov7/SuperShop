using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PanelTouchController PanelTouch;

    private float sensivity = 0.2f;
    private float maxAngleY = 80f;

    private float rotX = 0f;
    private float rotY = 0f;


    private void Update()
    {
        float camX = 0;
        float camY = 0;
        if (PanelTouch.isPressed) 
        {
            foreach(Touch touch in Input.touches)
            {
                if(touch.fingerId == PanelTouch.fingerId)
                {
                    if(touch.phase == TouchPhase.Moved)
                    {
                        camX = touch.deltaPosition.x;
                        camY = touch.deltaPosition.y;
                        rotY += camY;

                    }

                    //if(touch.phase == TouchPhase.Stationary)
                    //{
                    //    camX = 0;
                    //    camY = 0;
                    //}
                }
            }
        }
        transform.Rotate(Vector3.up * camX * sensivity);

        rotX -= camY * sensivity;
        rotX = Mathf.Clamp(rotX, -maxAngleY, maxAngleY);

        transform.localRotation = Quaternion.Euler(rotX, rotY, 0);




    }
}
