using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoorController : MonoBehaviour
{
    Animator animator;
    public GameObject ButtonOpenDoor;
    bool isOpen;


    private void Start()
    {
        animator = GetComponent<Animator>();
        ButtonOpenDoor.SetActive(false);
        isOpen = true;
        }
    public void OpeningDoor()
    {
        animator.SetTrigger("OpenDoor");
        ButtonOpenDoor.SetActive(false);
        isOpen = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isOpen)
        {
            if (other.tag == "MainCamera")
            {
                ButtonOpenDoor.SetActive(true);
            }
        }

    }
}
