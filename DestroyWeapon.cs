using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeapon : MonoBehaviour
{
    GameObject Fragile;
    public GameObject spot;
    Vector3 pos;
    // Start is called before the first frame update
    Material[] c1;
    Material c2;
    bool isnotbroken = true;
    public GameObject audioManager;
    AudioController audioController;



    private void Start()
    {
        audioController = audioManager.GetComponent<AudioController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon" || other.tag == "WeaponUsed" && other.GetComponent<BoxCollider>().enabled)
        {
            other.GetComponent<BoxCollider>().enabled = false;
            Destroy(other, 10f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("forbroke"))
        {
            //var rb = other.GetComponent<Rigidbody>();
            //rb.gameObject.SetActive(false);

            pos = new Vector3(other.transform.position.x, 0.01f, other.transform.position.z);
            var mats = other.GetComponent<MeshRenderer>().materials;
            foreach (var item in mats)
            {
                if (item.name.Contains("Liquid"))
                {
                    c2 = item;
                }
            }

            if (isnotbroken)
            {
                other.GetComponent<Explode>().BreakGlass();
                other.GetComponent<MeshRenderer>().gameObject.SetActive(false);

              

               

                isnotbroken = false;
                Invoke("RestoreBool", 0.1f);
            }
            GetSpot();
            audioController.RandomSoundEffect(1);
        }
    }


    void GetSpot()
    {
        float xrot = Random.Range(-180, 180);
        GameObject liquid = Instantiate(spot, pos, Quaternion.Euler(0f, 0f, 0f));
        liquid.GetComponent<MeshRenderer>().material = c2;
        liquid.transform.Rotate(0f, xrot, 0f);
        Destroy(liquid, 10f);
    }

    void RestoreBool()
    {
        isnotbroken = true;
    }
}
