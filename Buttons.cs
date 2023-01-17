using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Button newGame;
    public Button exitGame;


    public void NewGame()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("game");
    }

    public void ExitGame()
    {
        WaveSetup.numberOfWave = 1;
        Application.Quit();
    }



}
