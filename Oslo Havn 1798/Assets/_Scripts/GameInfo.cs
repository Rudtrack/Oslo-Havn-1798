using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    public GameObject gameInfo;
    //public GameObject gameInfoText;

    public GameObject aboutUsPanel;

    private static bool gameInfoRead = false;

    private void Start()
    {
        if(gameInfoRead == false)
        {
            gameInfo.SetActive(true);
            //gameInfoText.SetActive(true);
        }
        else
        {
            gameInfo.SetActive(false);
            //gameInfoText.SetActive(false);
        }
    }

    public void GameInfoCompleted()
    {
        gameInfoRead = true;
        gameInfo.SetActive(false);
        //gameInfoText.SetActive(false);
    }

    public void ViewAboutUs()
    {
        if(aboutUsPanel.activeInHierarchy == false)
        {
            aboutUsPanel.SetActive(true);
        }
        else
        {
            aboutUsPanel.SetActive(false);
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
