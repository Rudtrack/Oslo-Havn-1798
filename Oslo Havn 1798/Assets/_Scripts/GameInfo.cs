﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    public GameObject gameInfo;
    public GameObject HamburgerMenu;

    public GameObject aboutUsPanel;

    private static bool gameInfoRead = false;

    private void Start()
    {
        if(gameInfoRead == false)
        {
            gameInfo.SetActive(true);
            HamburgerMenu.SetActive(false);
        }
        else
        {
            gameInfo.SetActive(false);
            HamburgerMenu.SetActive(true);
        }
    }

    public void GameInfoCompleted()
    {
        gameInfoRead = true;
        gameInfo.SetActive(false);
        HamburgerMenu.SetActive(true);
    }

    public void ViewAboutUs()
    {
        if(aboutUsPanel.activeInHierarchy == false)
        {
            aboutUsPanel.SetActive(true);
            HamburgerMenu.SetActive(false);
        }
        else
        {
            aboutUsPanel.SetActive(false);
            HamburgerMenu.SetActive(true);
        }
    }

    public void TidvisButton()
    {
        Application.OpenURL("https://www.tidvis.no/");
    }

    public void OsloHavnButton()
    {
        Application.OpenURL("https://oslohavn1798.no/");
    }
}
