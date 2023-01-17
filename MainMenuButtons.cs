using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject car;
    public GameObject carOutline;
    public GameObject buttonStart;
    public GameObject buttonExit;
    public Image startImage;
    public Material HoverOn;
    public Material HoverOff;
    public GameObject ExitText;
        // Start is called before the first frame update
    void Start()
    {
        //startImage = buttonStart.GetComponent<Image>();
        carOutline.SetActive(false);
        ExitText.SetActive(false);
        InvokeRepeating("FlashImage", 0.01f, 2f);
        car.gameObject.GetComponent<MeshRenderer>().material = HoverOff;
    }

    void FlashImage()
    {
        startImage.gameObject.SetActive(false);
        Invoke("FlashImageOn", 1f);
    }

    void FlashImageOn()
    {
        startImage.gameObject.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("game");
    }

    public void ExitGame()
    {
        WaveSetup.numberOfWave = 1;
        Application.Quit();
        print("Exiting");
    }

    public void CarOnHoverOn()
    {
        car.gameObject.GetComponent<MeshRenderer>().material = HoverOn;
        print("Hovered");
        ExitText.SetActive(true);
    }

    public void CarOnHoverOff()
    {
        car.gameObject.GetComponent<MeshRenderer>().material = HoverOff;
        ExitText.SetActive(false);
    }


}
