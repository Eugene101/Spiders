using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSetup : MonoBehaviour
{
    private static bool created = false;
    int enemiesInWave;
    int upCoeff;
    public static int numberOfWave;
    GameObject enemiesLeftInWave;
    Text eLeft;
    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        enemiesLeftInWave = GameObject.Find("ToTheEnd");
        enemiesInWave = 1;
        Init();

    }


    public void Init()
    {
        numberOfWave++;
        enemiesInWave = 5 + numberOfWave;

        eLeft = enemiesLeftInWave.GetComponent<Text>();
        eLeft.text = enemiesInWave.ToString();
    }



    public void MinusEnemy()
    {
        enemiesInWave--;
        if (enemiesInWave > 0)
        {
            eLeft = enemiesLeftInWave.GetComponent<Text>();
            eLeft.text = enemiesInWave.ToString();
        }
        else
        {
            SceneManager.UnloadSceneAsync("game");
            SceneManager.LoadScene("game");
            enemiesInWave = 2 + numberOfWave;
        }
    }
}
