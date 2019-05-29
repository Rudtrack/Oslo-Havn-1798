using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Manager : MonoBehaviour {

    public Canvas MainUI;
    public Canvas LargeMap;
    public Canvas Objective;

    public GameObject qrButton;
    public GameObject arButton;

    public GameObject FishInfoBook;
    public GameObject TollInfoBook;

    private Passport passportScript;
    private bool cameraChoice = false;

    private void Awake()
    {
        /*MainUI.GetComponent<Canvas>().enabled = true;
        LargeMap.GetComponent<Canvas>().enabled = false;
        Objective.GetComponent<Canvas>().enabled = false;*/

        passportScript = GetComponent<Passport>();
    }

    private void Start()
    {
        qrButton.SetActive(false);
        arButton.SetActive(false);
    }

    //Click on map to enlarge it
    public void EnlargeMap()
    {
        LargeMap.GetComponent<Canvas>().enabled = true; 
        MainUI.GetComponent<Canvas>().enabled = false;

        //Application.OpenURL("https://www.google.no/maps/place/Gr%C3%BCnerl%C3%B8kka,+Oslo/@59.9245629,10.738274,13z/data=!3m1!4b1!4m5!3m4!1s0x46416e68bc978ae5:0x824c6a75515e8a8d!8m2!3d59.9238678!4d10.7578424");
    }

    //Takes you back to main UI
    public void BackArrow()
    {
        MainUI.GetComponent<Canvas>().enabled = true;
        LargeMap.GetComponent<Canvas>().enabled = false;
        Objective.GetComponent<Canvas>().enabled = false;
    }

    public void ActivateObjective()
    {
        MainUI.GetComponent<Canvas>().enabled = false;
        Objective.GetComponent<Canvas>().enabled = true;
    }

    public void ActivateCamera()
    {
        if(cameraChoice == false)
        {
            qrButton.SetActive(true);
            arButton.SetActive(true);
            cameraChoice = true;
        }
        else
        {
            qrButton.SetActive(false);
            arButton.SetActive(false);
            cameraChoice = false;
        }
    }

    public void ActivateQR()
    {
        SceneManager.LoadScene(1);
    }

    public void ActivateAR()
    {
        //Load the correct scene
    }

    public void ActivateFishMarket()
    {
        if(FishInfoBook.activeInHierarchy == true)
        {
            FishInfoBook.SetActive(false);
        }
        else
        {
            FishInfoBook.SetActive(true);
        }

        if (PlayerPrefs.GetInt("FishCompleted") == 1)
        {
            //passportScript.SearchStampList();
        }
    }

    public void ActivateToll()
    {
        if (TollInfoBook.activeInHierarchy == true)
        {
            TollInfoBook.SetActive(false);
        }
        else
        {
            TollInfoBook.SetActive(true);
        }
    }
    


    public void Objective0()
    {
        if(PlayerPrefs.GetInt("QR1_Status") == 0 || PlayerPrefs.HasKey("QR1_Status"))
        {
            Application.OpenURL("https://www.google.com/maps/place/R%C3%A5dhusgata,+0152+Oslo/@59.9083507,10.7457996,17z/data=!3m1!4b1!4m13!1m7!3m6!1s0x46416e887dfe6ab9:0x7bcb4671a0a08997!2sR%C3%A5dhusgata,+Oslo!3b1!8m2!3d59.9096701!4d10.7418397!3m4!1s0x46416e896c35c6ad:0xadf303d4d33d6972!8m2!3d59.9083507!4d10.7473472");
        }
        else if(PlayerPrefs.GetInt("QR1_Status") == 1)
        {
            SceneManager.LoadScene(2);
        }
        
    }

    public void Objective1()
    {
        Application.OpenURL("https://www.google.no/maps/place/Gr%C3%BCnerl%C3%B8kka,+Oslo/@59.9245629,10.738274,13z/data=!3m1!4b1!4m5!3m4!1s0x46416e68bc978ae5:0x824c6a75515e8a8d!8m2!3d59.9238678!4d10.7578424");
    }

    public void Objective2()
    {
        Application.OpenURL("https://www.google.no/maps/place/Gr%C3%BCnerl%C3%B8kka,+Oslo/@59.9245629,10.738274,13z/data=!3m1!4b1!4m5!3m4!1s0x46416e68bc978ae5:0x824c6a75515e8a8d!8m2!3d59.9238678!4d10.7578424");
    }

    public void Objective3()
    {
        Application.OpenURL("https://www.google.no/maps/place/Gr%C3%BCnerl%C3%B8kka,+Oslo/@59.9245629,10.738274,13z/data=!3m1!4b1!4m5!3m4!1s0x46416e68bc978ae5:0x824c6a75515e8a8d!8m2!3d59.9238678!4d10.7578424");
    }

    public void Objective4()
    {
        Application.OpenURL("https://www.google.no/maps/place/Gr%C3%BCnerl%C3%B8kka,+Oslo/@59.9245629,10.738274,13z/data=!3m1!4b1!4m5!3m4!1s0x46416e68bc978ae5:0x824c6a75515e8a8d!8m2!3d59.9238678!4d10.7578424");
    }

}
