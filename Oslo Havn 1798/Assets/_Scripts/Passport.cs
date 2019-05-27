using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Passport : MonoBehaviour
{
    public GameObject passport;
    private GameObject[] stamps;

    //public Image[] stampImages;

    private void Awake()
    {
        stamps = GameObject.FindGameObjectsWithTag("Stamp");
    }

    private void Start()
    {
        SearchStampList();

        passport.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ResetPassport();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            FishMarketCompleted();
        }
    }

    public void SearchStampList()
    {
        foreach (GameObject stamp in stamps)
        {
            if (stamp.name == "FishMarketStamp" && PlayerPrefs.GetInt("FishCompleted") == 1)
            {
                stamp.SetActive(true);
            }
            else if (stamp.name == "FishMarketStamp" && PlayerPrefs.GetInt("FishCompleted") == 0)
            {
                stamp.SetActive(false);
            }

            if (stamp.name == "ChurchStamp")
            {
                stamp.SetActive(true);
            }
        }
    }

    public void FishMarketCompleted()
    {
        PlayerPrefs.SetInt("FishCompleted", 1);
    }

    private void ResetPassport()
    {
        PlayerPrefs.DeleteAll();
    }
}
