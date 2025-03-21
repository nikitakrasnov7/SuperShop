using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public GameObject HeadFoodPointer;
    public GameObject ButtonThrow;

    private void Start()
    {
        ButtonThrow.SetActive(false);
    }

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
                            ButtonThrow.SetActive(true);

                            GameObject food = Instantiate(hit.collider.gameObject);
                            food.transform.position = HeadFoodPointer.transform.position;
                            food.transform.rotation = HeadFoodPointer.transform.rotation;
                            food.transform.parent = HeadFoodPointer.transform;
                            food.GetComponent<Rigidbody>().isKinematic = true;

                            Destroy(hit.collider.gameObject);
                        }

                    }
                }
            }
        }
    }
}
