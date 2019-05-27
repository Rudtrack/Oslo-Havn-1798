using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocationManager : MonoBehaviour
{
    public GameObject WelcomePanel;
    public TMP_Text WelcomeText;
    public TMP_Text LocationTextFish;

    [TextArea(5, 15)]
    public string FishWelcomeText;


    public bool isPaused;

    public 

    void Start()
    {

    }

    void Update()
    {


    }

    void PauseGame()
    {
        if (isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void FishWelcome()
    {
        WelcomePanel.SetActive(true);
        WelcomeText.text = FishWelcomeText;
        LocationTextFish.text = "OSLO FISH MARKET";
    }

    public void DisableFishWelcome()
    {
        WelcomePanel.SetActive(false);
        WelcomeText.text = "";
        LocationTextFish.text = "";
    }
}
