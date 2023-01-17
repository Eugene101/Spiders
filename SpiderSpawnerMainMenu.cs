using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawnerMainMenu : MonoBehaviour
{
    public int maxSpiders;
    public GameObject bornPoint;
    public GameObject spider;
    public int numberOfSpiders = 0;
    public float borntime = 0.1f;
    public Material[] spiderMats;
    public GameObject[] points;
    void Start()
    {
        InvokeRepeating("BornSpider", 2f, borntime);
    }

    void BornSpider()
    {
        if (numberOfSpiders < maxSpiders)
        {
            ////float xshift = Random.Range(-1f, 2f);
            ////float zshift = Random.Range(-1.5f, 1.5f);
            //Vector3 position = new Vector3(bornPoint.transform.position.x + xshift, bornPoint.transform.position.y, bornPoint.transform.position.z + zshift);
            //var rot = Quaternion.Euler(0, 102f, 0);
            GameObject Spider = Instantiate(spider, bornPoint.transform.position, transform.rotation);
            //int i = Random.Range(0, spiderMats.Length);
            //var SpiderMesh = Spider.transform.Find("mesh");
            //SpiderMesh.GetComponent<SkinnedMeshRenderer>().material = spiderMats[i];


            numberOfSpiders++;
        }


    }


}
