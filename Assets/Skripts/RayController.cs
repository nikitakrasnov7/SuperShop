using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RayController : MonoBehaviour
{
    [HideInInspector] public GameObject food;
    public GameObject HeadFoodPointer;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Food")
                    {
                        if (HeadFoodPointer.transform.childCount == 0)
                        {
                            GameObject food = Instantiate(hit.collider.gameObject);
                            food.transform.position = HeadFoodPointer.transform.position;
                            food.transform.parent = HeadFoodPointer.transform;
                            Destroy(hit.collider.gameObject);
                        }

                    }
                }
            }
        }
    }
}
