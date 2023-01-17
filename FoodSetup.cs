using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FoodSetup : MonoBehaviour
{
    public GameObject point;
    public GameObject[] FoodObjects;
    int typeOfFood;
  
    void Start()
    {
        InstallFood();
    }

    private void InstallFood()
    {
        typeOfFood = Random.Range(0, FoodObjects.Length);

        for (int yal = 0; yal < 4; yal++)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 position = new Vector3(point.transform.position.x, point.transform.position.y+ 0.3f * yal, point.transform.position.z - 0.5f * i);
                GameObject foodObject = Instantiate(FoodObjects[typeOfFood], position, transform.rotation);
            }
        }

        
    }
}
