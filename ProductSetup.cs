using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ProductSetup : MonoBehaviour
{
    public GameObject[] products;
    public GameObject[] shelvesStarted;
    public float[] shelvesHeight = { 0f, 0.47f, 1.04f, 1.4f };
    public GameObject shelveBasic;
    public int noOfShelves = 50;
    Vector3 position;

    public int numOfShelves;
    public int numOfproducts;
    
    public TextAsset textAssetData;
    public TextAsset textAssetDataRotation;

    List<Vector3> shelvepointsNew = new List<Vector3>();
    public List<Quaternion> shelvepointsRotation = new List<Quaternion>();

    public static bool shelvesDone;

    private void Awake()
    {
        LoadCoordinates();
        LoadRotation();
        SetShelves();
    }

    private void LoadCoordinates()
    {

        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        for (int i = 0; i < noOfShelves; i++)
        {
            //print((data[2 + (3 * i)] +" zzzz"));
            Vector3 pos = new Vector3(float.Parse(data[0 + (3 * i)]), float.Parse(data[1 + (3 * i)]), float.Parse(data[2 + (3 * i)]));
            shelvepointsNew.Add(pos);
        }
    }

    private void LoadRotation()
    {

        string[] data = textAssetDataRotation.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        for (int i = 0; i < noOfShelves; i++)
        {
            Quaternion rot = new Quaternion(float.Parse(data[0 + (4 * i)]), float.Parse(data[1 + (4 * i)]), float.Parse(data[2 + (4 * i)]), float.Parse(data[3 + (4 * i)]));
            shelvepointsRotation.Add(rot);
            print(rot + " rot");
        }
    }

    private void SetShelves()
    {
        for (int i = 0; i < shelvepointsNew.Count; i++)
        {
            position = shelvepointsNew[i];
            Quaternion rot = shelvepointsRotation[i];
            GameObject Shelve = Instantiate(shelveBasic, position, transform.rotation) as GameObject;
            Shelve.name = i.ToString();
        }

    }

   
}






