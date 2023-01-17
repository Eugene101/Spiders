using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpiderTouch : MonoBehaviour
{
    public GameObject redScreen;
    public GameObject audioManager;
    AudioController audioController;
    BasicEnemy basicEnemy;
    bool firstTouch = true;
    int health = 100;
    public int healthcoeff = 5;
    public Text healthText;
    void Start()
    {
        GameObject basicEnemy = GameObject.Find("BasicEnemy");
        redScreen.gameObject.SetActive(false);
        audioController = audioManager.GetComponent<AudioController>();
        InvokeRepeating("RestoreHealth", 13f, 13f);
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("spider") && firstTouch)
        {
            redScreen.gameObject.SetActive(true);
            Invoke("RedOff", 0.3f);
            audioController.RandomSoundEffect(1);
            var enemyScript = other.GetComponent<Spider>();
            health -= enemyScript.enemyDamage;
            firstTouch = false;
            healthText.text = health.ToString();
            if (health <= 0)
            {
                SceneManager.UnloadSceneAsync("Game");
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        redScreen.gameObject.SetActive(false);
        firstTouch = true;
    }

    private void RedOff()
    {
        redScreen.gameObject.SetActive(false);
    }

    private void RestoreHealth()
    {
        if (health < 100)
        {
            health += healthcoeff = 5;
            healthText.text = health.ToString();
        }
    }


}
