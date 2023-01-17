using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorque : MonoBehaviour
{
    public GameObject Pivot;
    static float torqueCoeff;
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody>();
        InvokeRepeating("ChangeCoeff", 1f, 5f);
    }

    void ChangeCoeff()
    {
      torqueCoeff = Random.Range(0.001f, 0.02f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Pivot.transform.position, -Vector3.forward, 90 * torqueCoeff);
    }
}
