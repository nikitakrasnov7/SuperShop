using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonThrowController : MonoBehaviour
{
    public GameObject ArmPointer;
    
    public void ThrowFood()
    {
        if (ArmPointer.transform.GetChild(0) != null)
        {
            GameObject food = ArmPointer.transform.GetChild(0).gameObject;
            food.GetComponent<Rigidbody>().isKinematic = false;

            Vector3 localForce = Vector3.right; 
            Vector3 globalForce = food.transform.TransformDirection(localForce); 

            food.GetComponent<Rigidbody>().AddForce(globalForce*3f, ForceMode.Impulse);
            food.transform.parent = null;

            gameObject.SetActive(false);
        }
    }
}
