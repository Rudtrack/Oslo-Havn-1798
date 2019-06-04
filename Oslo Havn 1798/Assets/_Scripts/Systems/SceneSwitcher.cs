using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject startButton;

    private void Update()
    {
        if(DoneTalking.convoFinished == true)
        {
            ShowStartButton();
        }
    }

    private void ShowStartButton()
    {
        startButton.SetActive(true);
    }

    public void LoadLandingPage()
    {
        SceneManager.LoadScene(0);
    }
}
