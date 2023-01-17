using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject[] listOfEnemies;
    public GameObject[] bornPoint;
    [HideInInspector]
    public int numberOfEnemies;
    public int maxnumberOfEnemies;
    public float timing;
    Vector3 position;
   

    private void Awake()
    {
        numberOfEnemies = 0;
    }

    void Start()
    {
       InvokeRepeating("InstallEnemy", 5f, timing);
    }

    
    void InstallEnemy()
    {
        if (numberOfEnemies<maxnumberOfEnemies)
        {
            int pointNumber = Random.Range(0, bornPoint.Length);
            int enemyNumber = Random.Range(0, listOfEnemies.Length);
            position = bornPoint[pointNumber].transform.position;
            GameObject Enemy = Instantiate(listOfEnemies[enemyNumber], position, transform.rotation);
            numberOfEnemies++;
        }
        
    }

}
