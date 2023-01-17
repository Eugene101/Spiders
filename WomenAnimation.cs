using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomenAnimation : MonoBehaviour
{
    Animator anim;
    bool isGenerated;
    int animnumber;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ResetBool();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !isGenerated)
        {
            anim.SetInteger("womenAnim", animnumber);
            isGenerated = true;

        }

        print("isGenerated" + isGenerated + " " + animnumber);

    }
    public void ResetBool()
    {
        isGenerated = false;
        animnumber = Random.Range(0, 7);
    }
}
