using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RankSystem : MonoBehaviour
{
    public static int rankPoints = 0;
    //public TMP_Text rankText;


    private void Awake()
    {
        rankPoints = PlayerPrefs.GetInt("Rank Points");
        //rankText.text = rankPoints.ToString();
    }

    public void IncreaseRankPoints()
    {
        rankPoints += 1;
        PlayerPrefs.SetInt("Rank Points", rankPoints);

        if (rankPoints <= 0 && rankPoints >= 1)
        {
            PlayerPrefs.SetString("Rank", "Peasant");
        }

        if (rankPoints <= 2 && rankPoints >= 4)
        {
            PlayerPrefs.SetString("Rank", "Trader");
        }

        if(rankPoints <= 5 && rankPoints >= 7)
        {
            PlayerPrefs.SetString("Rank", "Noble");
        }
    }

    public void DecreaseRankPoints()
    {
        rankPoints -= 1;
        PlayerPrefs.SetInt("Rank Points", rankPoints);

        if (rankPoints >= -1 && rankPoints <= -2)
        {
            PlayerPrefs.SetString("Rank", "Odd");
        }

        if (rankPoints >= -3 && rankPoints <= -5)
        {
            PlayerPrefs.SetString("Rank", "Shunned");
        }

        if (rankPoints >= -6 && rankPoints <= -7)
        {
            PlayerPrefs.SetString("Rank", "Evil");
        }
    }
}