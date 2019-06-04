using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    public GameObject gameInfo;
    public GameObject gameInfoText;

    private bool gameInfoRead = false;

    private void Start()
    {
        if(gameInfoRead == false)
        {
            gameInfo.SetActive(true);
            gameInfoText.SetActive(true);
        }
        else
        {
            gameInfo.SetActive(false);
            gameInfoText.SetActive(false);
        }
    }

    public void GameInfoCompleted()
    {
        gameInfoRead = true;
        gameInfo.SetActive(false);
        gameInfoText.SetActive(false);
    }
}
