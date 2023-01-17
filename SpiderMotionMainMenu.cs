using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMotionMainMenu : MonoBehaviour
{

    float dist;
    public float movementSpeed;
    Rigidbody rb;
    int i;
    SpiderSpawnerMainMenu spiderSpawnerMainMenu;
    void Start()
    {
        spiderSpawnerMainMenu = GameObject.Find("SpiderSpawner").GetComponent<SpiderSpawnerMainMenu>();
        rb = GetComponent<Rigidbody>();
        i = 0;
        //InvokeRepeating("ChangeSpeed", 1f, 3f);
    }

    ////void ChangeSpeed()
    ////{
    ////    movementSpeed = Random.Range(0.5f, 2f);
    ////}

    //private void Update()
    //{
    //    print("dist " + dist);
    //    transform.LookAt(spiderSpawnerMainMenu.points[i].transform.position);
    //    Vector3 dir = (spiderSpawnerMainMenu.points[i].transform.position - transform.position).normalized * movementSpeed;
    //    transform.position =  Vector3.Lerp(transform.position, spiderSpawnerMainMenu.points[i].transform.position, movementSpeed);
    //    rb.velocity = dir;
    //    dist = Vector3.Distance(transform.position, spiderSpawnerMainMenu.points[i].transform.position);

    //    if (dist < 0.3f && i < 5)
    //    {
    //        i++;
    //    }

    //    else if (dist < 0.3f && i >= 5)
    //    {
    //        spiderSpawnerMainMenu.numberOfSpiders--;
    //        i = 0;
    //        Destroy(gameObject);

    //    }

    //}

    private void FixedUpdate()
    {
        print("dist " + dist);
        transform.LookAt(spiderSpawnerMainMenu.points[i].transform.position);
        //Vector3 dir = (spiderSpawnerMainMenu.points[i].transform.position - transform.position).normalized * movementSpeed;
        //transform.position = Vector3.Lerp(transform.position, spiderSpawnerMainMenu.points[i].transform.position, movementSpeed);
        transform.Translate(Vector3.forward * movementSpeed);
        //rb.velocity = dir;
        dist = Vector3.Distance(transform.position, spiderSpawnerMainMenu.points[i].transform.position);

        if (dist < 0.5f && i < 5)
        {
            i++;
        }

        else if (dist < 0.5f && i >= 5)
        {
            spiderSpawnerMainMenu.numberOfSpiders--;
            i = 0;
            Destroy(gameObject);

        }

    }


}
