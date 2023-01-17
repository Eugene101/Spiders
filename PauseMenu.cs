using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Image pauseMenu;
    public Image poison;
    public Color currentColor;
    public Button sound;
    public Button restart;
    public Button quitgame;
    public Button returnButton;
    public Text numOfEnemies;
    public int killedEnemies;
    public static bool isMenu1on;
    bool changed;
    public Text Soundon;
    public Text Soundoff;
    public static bool soundon = true;
    bool timeshift = true;
    float time = 0f;
    public static float unscaledTime = 1;
    public GameObject LaserLeft;
    public GameObject LaserRight;
    WaveSetup waveSetup;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
        LaserLeft.gameObject.SetActive(false);
        LaserRight.gameObject.SetActive(false);
        InvokeRepeating("CheckNewKills", 1f, 1f);
        InvokeRepeating("ResetTimeShift", 1f, unscaledTime);
    }
    // Update is called once per frame
    void Update()
    {
        print(timeshift + " timeshift " + isMenu1on);

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button2) && !isMenu1on && timeshift)
        {
            timeshift = false;
            Time.timeScale = 0f;
            isMenu1on = true;
            pauseMenu.gameObject.SetActive(true);
            LaserLeft.gameObject.SetActive(true);
            LaserRight.gameObject.SetActive(true);
        }

        if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(UxrHandSide.Right, UxrInputButtons.Button2) && isMenu1on && timeshift)
        {
            timeshift = false;
            Time.timeScale = 1f;
            isMenu1on = false;
            pauseMenu.gameObject.SetActive(false);
            LaserLeft.gameObject.SetActive(false);
            LaserRight.gameObject.SetActive(false);

        }

        if (!timeshift)
        {
            time += 0.02f;
            if (time > 1)
            {
                timeshift = true;
                //time = 0;
            }
        }



        if (changed)
        {
            PlayerPrefs.SetInt("mySound", soundon ? 1 : 0);

            if (soundon)
            {
                Soundon.gameObject.SetActive(true);
                Soundoff.gameObject.SetActive(false);
                AudioListener.pause = false;
            }

            else if (!soundon)
            {
                Soundon.gameObject.SetActive(false);
                Soundoff.gameObject.SetActive(true);
                AudioListener.pause = true;
            }

            changed = false;
        }

    }

    public void Exitapp()
    {
        WaveSetup.numberOfWave = 1;
        Application.Quit();
    }

    void CheckNewKills()
    {
        numOfEnemies.text = killedEnemies.ToString();
    }

    public void SoundCh()
    {
        soundon = !soundon;
        changed = true;
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1f;
        isMenu1on = false;
        pauseMenu.gameObject.SetActive(false);
        LaserLeft.gameObject.SetActive(false);
        LaserRight.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("game");
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("game");
        SceneManager.LoadScene("game");
    }


}
