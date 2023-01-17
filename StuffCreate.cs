using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffCreate : MonoBehaviour
{
    public GameObject shelve;
    public GameObject cashier;
    public GameObject bakery;
    Vector3 position;
    public int numOfShelves;
    public int numOfBakery;
    public int numOfCashier;
    public int numOfBeverage;
    public int numOfPumpkin;
    
    public int linesOfShelves;
    public int linesOfPumpkin;
    
    float xshift;
    float zshift;
    public GameObject shelvePoint;
    public GameObject bakeryPoint;
    public GameObject cashierPoint;

    public GameObject[] points;
    public GameObject[] stuff;

    private void Awake()
    {
        InstallShelves();
        InstallBakery();
        InstallCashier();
        InstallBevegare();
        InstallPumpkin();
    }

    void InstallShelves()
    {
        for (int j = 0; j < linesOfShelves; j++)
        {
            for (int i = 0; i < numOfShelves; i++)
            {
                zshift = -i * 3;
                xshift = -j * 5;
                position = new Vector3(points[0].transform.position.x + xshift, points[0].transform.position.y , points[0].transform.position.z + zshift);
                GameObject Shelve = Instantiate(stuff[0], position, transform.rotation);
            }
        }


    }

    void InstallBakery()
    {
        for (int i = 0; i < numOfBakery; i++)
        {
            zshift = -i * 1.1f;
            position = new Vector3(points[1].transform.position.x, points[1].transform.position.y, points[1].transform.position.z + zshift);
            GameObject Bakery = Instantiate(stuff[1], position, transform.rotation);
        }
    }

    void InstallCashier()
    {
        for (int i = 0; i < numOfCashier; i++)
        {
            xshift = -i * 5;
            position = new Vector3(points[2].transform.position.x + xshift, points[2].transform.position.y, points[2].transform.position.z);
            GameObject Cashier = Instantiate(stuff[2], position, Quaternion.Euler (90f,90f,180f));
        }
    }

    void InstallBevegare()
    {
        for (int i = 0; i < numOfBeverage; i++)
        {
            zshift = -i * 1.1f; ;
            position = new Vector3(points[3].transform.position.x, points[3].transform.position.y, points[3].transform.position.z + zshift);
            GameObject Bevegare = Instantiate(stuff[3], position, Quaternion.Euler(0f, 90f, 0f));
        }
    }

    void InstallPumpkin()
    {
        for (int j = 0; j < linesOfPumpkin; j++)
        {
            for (int i = 0; i < numOfPumpkin; i++)
            {
                zshift = i * 3;
                xshift = j * 4;
                position = new Vector3(points[4].transform.position.x + xshift, points[4].transform.position.y, points[4].transform.position.z + zshift);
                GameObject PumpkinStand = Instantiate(stuff[4], position, transform.rotation);
            }
        }


    }

}
