using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingMeals : MonoBehaviour
{
    Rigidbody rb;
    public float k;
    // Start is called before the first frame update
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "GrabVolumeSmall")
        {
            rb.AddForce(Vector3.forward*k);
        }
    }

}
