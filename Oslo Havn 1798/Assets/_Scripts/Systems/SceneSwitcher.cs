using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject startButton;

    private void Update()
    {
        if(DoneTalking.convoEnded == true)
        {

        }
    }

    public void StartJourney()
    {
        SceneManager.LoadScene(0);
    }
}
