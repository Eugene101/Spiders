using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Environment : MonoBehaviour
{
    public float TotalHealth = 100f;
    public float ventilationCoeff = 0.1f;
    EnemyCreator enemyCreator;
    GameObject EnemyManager;
    //public GameObject poisonScreen;
    float coloralpha =0f;
    MeshRenderer meshRenderer;
    Material mat;
    public Image effect;
    public Text increasing;
    public Text polutionRate;
    public Text precent;
    int enemiesNumber;
    
    Color c1;
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager = GameObject.Find("EnemyManager");
        enemyCreator = EnemyManager.GetComponent<EnemyCreator>();
        InvokeRepeating("Ventilation", 1f, 5f);
        //mat = poisonScreen.GetComponent<MeshRenderer>().material;


    }

    void Ventilation()
    {
        TotalHealth += ventilationCoeff;
    }

    private void FixedUpdate()
    {
       
        if (TotalHealth<=0f)
        {
            print("Die");
            TotalHealth = 0f;
        }

        else if (TotalHealth>=100f)
        {
            TotalHealth = 100f;
        }

        effect.color = new Color(effect.color.r, effect.color.g, effect.color.b, coloralpha);
        coloralpha = (1f - TotalHealth/100)/4f;

        enemiesNumber = enemyCreator.numberOfEnemies;

        if (enemiesNumber<3)
        {
            increasing.text = "very slow";
            increasing.color = Color.green;
            
        }

        else if (enemiesNumber >= 3 && enemiesNumber <6)
        {
            increasing.text = "slow";
            increasing.color = Color.yellow;
           
        }

        else if (enemiesNumber >= 6 && enemiesNumber < 9)
        {
            increasing.text = "fast";
            increasing.color = Color.magenta;
            polutionRate.color = Color.magenta;
            precent.color = Color.magenta;
        }

        else
        {
            increasing.text = "very fast";
            increasing.color = Color.red;
         
        }

        if (Mathf.Round(100f - TotalHealth) <25)
        {
            polutionRate.color = Color.green;
            precent.color = Color.green;
        }

        else if (Mathf.Round(100f - TotalHealth) >= 25 && Mathf.Round(100f - TotalHealth) < 50)
        {
            polutionRate.color = Color.yellow;
            precent.color = Color.yellow;
        }

        else if (Mathf.Round(100f - TotalHealth) >= 50 && Mathf.Round(100f - TotalHealth) < 75)
        {
            polutionRate.color = Color.magenta;
            precent.color = Color.magenta;
        }

        else
        {
            polutionRate.color = Color.red;
            precent.color = Color.red;
        }

        polutionRate.text = (Mathf.Round (100f - TotalHealth)).ToString();

        //coloralpha = 1 - (0.01f * TotalHealth);
    }



}
